using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace YPlateVision
{
    [Serializable]
    public class Settings
    {
        public YoloSettings yoloSettings = new YoloSettings();

        /// <summary>
        /// Текстовое поле для "заметок", никак не используется программой
        /// </summary>
        public string comment = "";

        /// <summary>
        /// Углы, на которые буду поворачиваться изображения, если при использовании заданных для камер результат получен не будет
        /// </summary>
        public int[] angles = new int[] {-7, 7, -14, 14, -21, 21};

        /// <summary>
        /// Углы поворота изображений, полученных с разных камер. Подбираются в зависимости от ориентации камеры
        /// </summary>
        public List<CamAngle> camAngles = new List<CamAngle>();

        /// <summary>
        /// Закрывать окно крестиком в верхнем правом углу: true - закрывать как обычно, false - сворачивать
        /// </summary>
        public bool allowClose = false;

        /// <summary>
        /// Минимальное значение уверенности при распознавании символа номера, ниже которого результат не будет учитываться
        /// </summary>
        public double thresholdForSymbols = 0.7;

        /// <summary>
        /// Минимальное значение уверенности при распознавании рамки номера, ниже которого результат не будет учитываться
        /// </summary>
        public double thresholdForPlates = 0.4;

        /// <summary>
        /// Переставлять буквы в квадратных номерах прицепов, чтобы порядок соответствовал прямоугольным номерам
        /// </summary>
        public bool rearrangeSquare = true;

        /// <summary>
        /// Порт для HTTP-сервера
        /// </summary>
        public int HTTPport = 1025;

        /// <summary>
        /// Запускать программу свёрнутой в трей
        /// </summary>
        public bool startMinimized = false;

        public Settings()
        {

        }

        public void Load(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Settings tmp = (Settings)xmlSerializer.Deserialize(fs);
                fs.Close();
                this.thresholdForPlates = tmp.thresholdForPlates;
                this.thresholdForSymbols = tmp.thresholdForSymbols;
                this.camAngles.Clear();
                this.camAngles = tmp.camAngles;
                this.allowClose = tmp.allowClose;
                this.angles = tmp.angles;
                this.comment = tmp.comment;
                this.rearrangeSquare = tmp.rearrangeSquare;
                this.HTTPport = tmp.HTTPport;
                this.startMinimized = tmp.startMinimized;
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream("settings.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, this);
                fs.Close();
            }
        }
    }

    [Serializable]
    public class YoloSettings
    {
        public string yoloPlatesModel = ""; // Путь к файлу с обученной моделью Yolo для поиска рамок номера
        public string yoloNumModel = ""; // Путь к файлу с обученной моделью Yolo для распознавания символов
    }

    public struct CamAngle
    {
        public string camRegExp;
        public int value;
    }
}
