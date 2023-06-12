using System;
using System.Text.RegularExpressions;
using System.Drawing;

using Yolov5Net.Scorer;

namespace YPlateVision
{
    public static class Utility
    {
        public static string FilterO0(string number, PlateType plateType, bool rearrange = true)
        {
            if (number is null)
                return null;

            if (number == "ERR")
            {
                return "ERR";
            }

            if (plateType == PlateType.Rectangle)
            {
                // если условие выполняется, то это номер машины, а если не выполняется - то прицепа
                if (number[1] == '0' || number[1] == '1' || number[1] == '2' || number[1] == '3' || number[1] == '4' || number[1] == '5' || number[1] == '6' || number[1] == '7' || number[1] == '8' || number[1] == '9')
                {
                    // у машины все символы, начиная с 6, - цифры
                    number = number.Substring(0, 6) + number.Substring(6).Replace('О', '0');
                }
                else
                {
                    // у прицепа больше нигде не может быть букв
                    number = number.Substring(0, 2) + number.Substring(2).Replace('О', '0');
                }
            }
            else if(plateType == PlateType.Sqare)
            {
                // если номер начинается с цифры, то это прицеп и ?надо? поменять порядок цифр
                if (number[0] == '0' || number[0] == '1' || number[0] == '2' || number[0] == '3' || number[0] == '4' || number[0] == '5' || number[0] == '6' || number[0] == '7' || number[0] == '8' || number[0] == '9')
                {
                    if(rearrange)
                    number = number.Substring(4, 2).Replace('0', 'O')
                       + number.Substring(0, 1)
                       + number.Substring(1, 3).Replace('0', 'O')
                       + number.Substring(6).Replace('O', '0');
                }
                else
                {
                    number = number.Substring(0, 1)
                       + number.Substring(1, 3).Replace('О', '0')
                       + number.Substring(4, 2).Replace('0', 'O')
                       + number.Substring(6).Replace('О', '0');
                }


                //return number;
            }
            Regex numCar = new Regex(@"^\D{1}\d{3}\D{2}\d{2,3}$"); // 1 буква, 3 цифры, 2 буквы, 2-3 цифры (машина)
            Regex numTrailerS = new Regex(@"^\D{2}\d{6,7}$"); // 2 буквы, остальное цифры (прицеп квадратный)
            Regex numTrailerP = new Regex(@"^\d{4}\D{2}\d{2,3}$"); // 4 цифры, 2 буквы, 2-3 цифры (прицеп прямоугольный)

            if (numCar.Match(number).Success)
                return number;
            else if (numTrailerS.Match(number).Success)
                return number;
            else if (numTrailerP.Match(number).Success)
                return number;
            else
                return "ERR";
        }

        public static YoloPrediction ChangeOto0(YoloPrediction yPred)
        {
            float tmpScore = yPred.Score;
            RectangleF tmpRec = new RectangleF(yPred.Rectangle.Location, yPred.Rectangle.Size);
            return new YoloPrediction()
            {
                Label = new YoloLabel { Name = "0" },
                Score = tmpScore,
                Rectangle = tmpRec
            };
        }

        public static int GetAngle(Settings settings, string path)
        {
            foreach (CamAngle ca in settings.camAngles)
            {
                if (path.LastIndexOf(ca.camRegExp) > 0)
                {
                    return ca.value;
                }
            }
            return 0;
        }

        public static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
