using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;

using Yolov5Net.Scorer;

namespace YPlateVision
{
    /// <summary>
    /// Вспомогательный статический класс, содержащий в себе разные методы обработки изображений
    /// </summary>
    public static class ImageProcessing
    {
        /// <summary>
        /// "Вырезание" фрагмента изображения
        /// </summary>
        /// <param name="srcImage">Исходное изображение</param>
        /// <param name="srcRegion">Границы фграмента для вырезки</param>
        /// <returns>Выбранный фрагмент в виде нового изображения</returns>
        public static Image GetRegion(Image srcImage, RectangleF srcRegion)
        {
            Image destImage = new Bitmap((int)srcRegion.Width, (int)srcRegion.Height);
            using (Graphics gr = Graphics.FromImage(destImage))
            {
                Rectangle destRegion = new Rectangle(0, 0, (int)srcRegion.Width, (int)srcRegion.Height);
                gr.DrawImage(srcImage, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
            return destImage;
        }

        /// <summary>
        /// Масштабирование изображения с сохранением пропорций
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="maxWidth">Желаемая ширина после масштабирования (не факт что будет достигнута из-за сохранения пропорций)</param>
        /// <param name="maxHeight">Желаемая высота после масштабирования (не факт что будет достигнута из-за сохранения пропорций)</param>
        /// <returns>Новое изображение с другими размерами</returns>
        public static Image Scale(Image srcImage, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / srcImage.Width;
            var ratioY = (double)maxHeight / srcImage.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(srcImage.Width * ratio);
            var newHeight = (int)(srcImage.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(srcImage, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        /// <summary>
        /// Наклон (сдвиг, смещение) изображения
        /// </summary>
        /// <param name="srcImage">Исходное изображение</param>
        /// <param name="offset">Количество точек, на которое будет произведён сдвиг/наклон</param>
        /// <returns></returns>
        public static Image Skew(Image srcImage, int offset)
        {
            Point[] destinationPoints = {
                new Point(0 + offset/2, 0),                 // destination for upper-left point of original
                new Point(srcImage.Width + offset/2, 0),    // destination for upper-right point of original
                new Point(0 - offset/2, srcImage.Height)};  // destination for lower-left point of original

            Image res = new Bitmap(srcImage.Width, srcImage.Height);

            Graphics g = Graphics.FromImage(res);
            g.DrawImage(srcImage, destinationPoints);

            return res;
        }

        /// <summary>
        /// Поворот изображения относительно центра
        /// </summary>
        /// <param name="srcImage">Исходное изображение</param>
        /// <param name="angle">Угол поворота</param>
        /// <returns></returns>
        public static Image Rotate(Image srcImage, int angle, bool needHighQuality = false)
        {
            Bitmap res = new Bitmap(srcImage.Width, srcImage.Height);
            res.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);

            Graphics g = Graphics.FromImage(res);
            
            if(needHighQuality)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TranslateTransform(res.Width / 2, res.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-res.Width / 2, -res.Height / 2);
            g.DrawImage(srcImage, 0, 0);

            return res;
        }

        /// <summary>
        /// Обвод рамочками объектов на изображении на основе результатов распознавания Yolo
        /// </summary>
        /// <param name="srcImage">Исходное изображение</param>
        /// <param name="predictions">Результаты распознавания Yolo</param>
        /// <param name="color">Цвет рамки</param>
        /// <param name="lineWeight">Тодщина рамки</param>
        /// <returns></returns>
        public static Image MarkObjects(Image srcImage, List<YoloPrediction> predictions, Color color, int lineWeight = 2, bool drawLabels = false)
        {
            Image res = new Bitmap(srcImage);
            Graphics g = Graphics.FromImage(res);
            foreach (var prediction in predictions)
            {
                Pen p = new Pen(color, lineWeight);
                g.DrawRectangles(p, new[] { prediction.Rectangle });

                if (drawLabels)
                {
                    var (x, y) = (prediction.Rectangle.X, prediction.Rectangle.Y);
                    //g.DrawString($"{prediction.Label.Name}",
                    g.DrawString($"{Math.Round(prediction.Score, 2)}",
                            new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.DeepPink),
                            new PointF(x, y));
                }
            }

            return res;
        }

        /// <summary>
        /// Увеличение контрастности изображения
        /// </summary>
        /// <param name="srcImage">Исходное изображение</param>
        /// <param name="contrast"></param>
        /// <returns></returns>
        public static Image IncreaseContrast(Image srcImage, float contrast)
        {
            Image res = new Bitmap(srcImage);
            Graphics g = Graphics.FromImage(res);

            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cm = new ColorMatrix(new float[][] {
            new float[] { contrast , 0f,0f,0f,0f },
            new float[] { 0f, contrast , 0f,0f,0f },
            new float[] { 0f, 0f, contrast , 0f,0f },
            new float[] {  0f,0f,0f,1f,0f },
            new float[] { 0.001f,0.001f,0.001f,0f,1f} });
            ia.SetColorMatrix(cm);

            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, res.Width, res.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();

            return res;
        }
    }
}
