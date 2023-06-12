using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Yolov5Net.Scorer;

namespace YPlateVision
{
    public class YoloRecognizer
    {
        public string modelDir = @"";
        public string yoloPlatesModel = "plates.onnx";
        public string yoloNumModel = "numbers.onnx";

        public PlateType PlateFound    { get; private set; } = PlateType.None;

        public YoloScorer<YModelPlates> yPlates;
        public YoloScorer<YModelNumbers> yNumsLetters;

        public TimeSpan recTime = new TimeSpan();

        public List<YoloPrediction> yPredSymbols;

        private Image onlyPlate;

        private int defaultAngle;

        private int minSymbols = 8;

        private readonly Settings settings;

        /// <summary>
        /// Изображение с результатами первого этапа - обозначенными номерами
        /// </summary>
        public Image StageOne { get; private set; }

        /// <summary>
        /// Изображение с результатами второго этапа - цифрами на номере
        /// </summary>
        public Image StageTwo { get; private set; }

        public YoloRecognizer()
        {
            yPlates = new YoloScorer<YModelPlates>(modelDir + yoloPlatesModel);
            yNumsLetters = new YoloScorer<YModelNumbers>(modelDir + yoloNumModel);
        }

        public YoloRecognizer(ref Settings s)
        {
            yPlates = new YoloScorer<YModelPlates>(modelDir + yoloPlatesModel);
            yNumsLetters = new YoloScorer<YModelNumbers>(modelDir + yoloNumModel);

            this.settings = s;
        }

        /// <summary>
        /// Запускает процесс поиска номера и распознавания символов на нём
        /// </summary>
        /// <param name="image">Изображение для поиска объектов</param>
        /// <param name="recoNumNeeded">УБРАТЬ потом</param>
        /// <returns>Номер или "ERR" если не удалось найти его или распознать символы</returns>
        public string Recognize(Image image, int defaultAngle, int recoNumNeed = 8)
        {
            this.defaultAngle = defaultAngle;
            ///// установка значений по умолчанию /////
            PlateFound = PlateType.None;
            this.minSymbols = recoNumNeed;
            DateTime t = DateTime.Now;

            ///// поиск рамки номера /////
            FindPlate(ref image);

            if (PlateFound == PlateType.None)
                return "ERR";

            ///// распознавание цифр и букв /////

            yPredSymbols = FindSymbols(onlyPlate);

            string number = "";
            if (yPredSymbols != null && yPredSymbols.Average(item => item.Score) > 0.8)
            {
                foreach (YoloPrediction symbol in yPredSymbols)
                {
                    number += symbol.Label.Name;
                }
                StageTwo = ImageProcessing.MarkObjects(onlyPlate, yPredSymbols, Color.OrangeRed, 3, true);
                recTime = DateTime.Now - t;
                return number;
            }
            else
            {
                foreach (int angle in settings.angles)
                {
                    yPredSymbols = FindSymbols(ImageProcessing.Rotate(onlyPlate, angle));
                    if (yPredSymbols != null && yPredSymbols.Average(item => item.Score) > 0.8)
                    {
                        foreach (YoloPrediction symbol in yPredSymbols)
                        {
                            number += symbol.Label.Name;
                        }
                        StageTwo = ImageProcessing.MarkObjects(ImageProcessing.Rotate(onlyPlate, angle), yPredSymbols, Color.OrangeRed, 3, true);
                        recTime = DateTime.Now - t;
                        return number;
                    }
                }
            }

            StageTwo = onlyPlate;
            return "ERR";
        }

        private void FindPlate(ref Image image)
        {
            Image rotated = new Bitmap(image);

            if (defaultAngle > 1 || defaultAngle < -1)
                rotated = ImageProcessing.Rotate(image, defaultAngle);

            List<YoloPrediction> platePredictions = yPlates.Predict(rotated); // поиск всего похожего на рамку номера

            for (int i = 0; i < platePredictions.Count; i++) // убирание того, у чего уверенность меньше заданной в настройках
            {
                if (platePredictions[i].Score < settings.thresholdForPlates)
                {
                    platePredictions.RemoveAt(i);
                    i--;
                }
            }
            if (platePredictions.Count < 1)
            {
                foreach (int angle in settings.angles)
                {
                    rotated = ImageProcessing.Rotate(image, angle);
                    platePredictions = yPlates.Predict(rotated); // поиск всего похожего на рамку номера
                    for (int i = 0; i < platePredictions.Count; i++) // убирание того, у чего уверенность меньше заданной в настройках
                    {
                        if (platePredictions[i].Score < settings.thresholdForPlates)
                        {
                            platePredictions.RemoveAt(i);
                            i--;
                        }
                    }
                    if (platePredictions.Count > 0) break;
                }
            }

            if (platePredictions.Count > 1)
            {
                platePredictions.Sort((a,b)=>b.Score.CompareTo(a.Score));
            }
            if (platePredictions.Count < 1)
            {
                PlateFound = PlateType.None;
            }
            else
            {
                if (platePredictions[0].Label.Id == 0)
                    PlateFound = PlateType.Rectangle;
                else if (platePredictions[0].Label.Id == 1)
                    PlateFound = PlateType.Sqare;

                // обвести прямоугольник вокруг номера на исходной картинке (дальше не используется, нужно только для вывода на экран)
                StageOne = ImageProcessing.MarkObjects(rotated, platePredictions, Color.Yellow, 4);

                // вырезать из исходного изображения фрагмент с номером и привести его размер к тому, на котором была обучена нейросеть (480 пикселей)
                onlyPlate = ImageProcessing.Scale(
                                ImageProcessing.GetRegion(rotated, platePredictions[0].Rectangle),
                                480, 300);
            }
        }

        private List<YoloPrediction> FindSymbols(Image image)
        {
            List<YoloPrediction> predSymbols = yNumsLetters.Predict(image);

            // убирание того, у чего уверенность меньше заданного предела
            for (int i = 0; i < predSymbols.Count; i++)
            {
                if (predSymbols[i].Score < settings.thresholdForSymbols)
                {
                    predSymbols.RemoveAt(i);
                    i--;
                }
            }

            // если не распозналось достаточное количество симоволов (8 по умолчанию)
            if (predSymbols.Count < minSymbols)
                return null;
            
            // сортировка полученных прямоугольников по оси X
            var sortedTmp = from c in predSymbols
                            orderby c.Rectangle.X
                            select c;

            List<YoloPrediction> sortedBoxes = new List<YoloPrediction>(sortedTmp);

            // вычисление средней высоты символа, чтобы отделить 0 от O //
            // вычисление середины номера, чтобы разделить квадратный на 2 строки //
            double avgHeight = 0;
            double midLane = 0;
            foreach (var box in sortedBoxes)
            {
                avgHeight += box.Rectangle.Height;
                midLane += box.Rectangle.Y;
            }
            avgHeight /= sortedBoxes.Count;
            midLane /= sortedBoxes.Count;


            if (PlateFound == PlateType.Rectangle) // если нашёлся прямоугольный номер
            {
                // поиск всех меток O и змена тех, у которых высота больше средней, на 0
                for (int j = 0; j < sortedBoxes.Count; j++)
                {
                    if (sortedBoxes[j].Label.Name == "О" && sortedBoxes[j].Rectangle.Height > avgHeight) // у цифр высота больше средней
                    {
                        sortedBoxes[j] = Utility.ChangeOto0(sortedBoxes[j]);
                    }
                }
            }


            if (PlateFound == PlateType.Sqare) // если нашёлся квадратный номер
            {
                List<YoloPrediction> boxesLine1 = new List<YoloPrediction>(sortedBoxes.Count());
                List<YoloPrediction> boxesLine2 = new List<YoloPrediction>(sortedBoxes.Count());

                double avgWidth = 0;
                foreach (YoloPrediction box in sortedBoxes)
                {
                    if (box.Rectangle.Y < midLane)
                    {
                        boxesLine1.Add(box);
                        avgWidth += box.Rectangle.Width; // средняя высота символа считается только на основе верхнего ряда, так как в нижнем номер региона меньше по размеру
                    }
                    else
                    {
                        boxesLine2.Add(box);
                    }
                }
                avgWidth /= boxesLine1.Count;

                boxesLine1.AddRange(boxesLine2);
                sortedBoxes = boxesLine1;

                if (sortedBoxes[0].Label.Name == "О" && sortedBoxes[0].Rectangle.Width <= (avgWidth * 1.2))
                {
                    sortedBoxes[0] = Utility.ChangeOto0(sortedBoxes[0]); // остальные заменятся в зависимости от позиции
                }
            }
            ///////////////////////////////////////////////////////////////

            return sortedBoxes;
        }
    }

    public class NumLetterEntry
    {
        public int place;
        public int count;
        public double confidence;
        public string label;

        public NumLetterEntry()
        {
            place = 0;
            count = 0;
            confidence = 0;
            label = "";
        }

        public NumLetterEntry(int place, int count, double avgConfidence, string label)
        {
            this.place = place;
            this.count = count;
            this.confidence = avgConfidence;
            this.label = label;
        }
    }

    public enum PlateType
    {
        None,
        Rectangle,
        Sqare
    }
}
