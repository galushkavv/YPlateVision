using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

using Yolov5Net.Scorer;

namespace YPlateVision
{
    public partial class FormMain : Form
    {
        Settings settings = new Settings();
        string settingsFile = "settings.xml";
        string pictureDir = "";

        YoloRecognizer yRecognizer;

        Image onlyPlate;
        string bestNumber = "";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(File.Exists(settingsFile))
            {
                try
                {
                    settings.Load(settingsFile);
                }
                catch(Exception ex)
                {
                    Log("Ошибка при чтении файла с настройками: " + ex.Message);
                    Logger.Write("Ошибка при чтении файла с настройками: " + ex.Message);
                }
            }
            if(settings.startMinimized)
            {
                this.Hide();
            }
            pictureDir = @"D:\06\30";
            if (Directory.Exists(pictureDir))
            {
                DirectoryInfo dir = new DirectoryInfo(pictureDir);
                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {
                    listBoxPictures.Items.Add(file.Name);
                }
                if(listBoxPictures.Items.Count > 0)
                    recognizeFolderToolStripMenuItem.Enabled = true;
            }
            splitContainerMain.SplitterDistance = 200;
            splitContainerPictures.SplitterDistance = 482;

            yRecognizer = new YoloRecognizer(ref settings);

            Thread httpSrvThread = new Thread(HTTPThread);
            httpSrvThread.Start();
            Log("Start");
        }

        ////////////////////////////////////////////////////////
        // делегаты для вызова из других потоков через Invoke //
        ////////////////////////////////////////////////////////
        public delegate void ShowText(string text);
        public delegate void ShowBitmap(Bitmap bmp, PictureBoxes pictureBox);

        private void Log(string text)
        {
            richTextBox1.Text += "[" + DateTime.Now.ToString("dd MMM yyyy, HH:mm:ss") + "] " + text + "\n\n";
        }

        public void SetLabelNumberText(string text)
        {
            labelNumber.Text = text;
        }

        public void ShowImage(Bitmap srcImage, PictureBoxes whatPictureBox)
        {
            if (whatPictureBox == PictureBoxes.Source)
            {
                pictureBoxSrc.Image = ImageProcessing.Scale(srcImage, pictureBoxSrc.Size.Width, pictureBoxSrc.Size.Height);
                pictureBoxSrc.Invalidate();
            }
            else if (whatPictureBox == PictureBoxes.NumberPlate)
            {
                pictureBoxOnlyPlate.Image = ImageProcessing.Scale(srcImage, pictureBoxOnlyPlate.Size.Width, pictureBoxOnlyPlate.Size.Height);
                pictureBoxOnlyPlate.Invalidate();
            }
        }

        private void HTTPThread()
        {
            YoloRecognizer yRecognizer = new YoloRecognizer(ref settings);

            HttpListener httpSrv = new HttpListener();
            httpSrv.Prefixes.Add("http://localhost:"+settings.HTTPport+"/");
            try
            {
                httpSrv.Start();
                Logger.Write("HTTP-сервер запущен");
            }
            catch (Exception e)
            {
                Logger.Write("Ошибка при запуске HTTP-сервера");
                MessageBox.Show("Ошибка при запуске HTTP-сервера. Распознавание через HTTP работать не будет");
                return;
            }
            while (true)
            {
                HttpListenerContext context = httpSrv.GetContext();
                HttpListenerRequest request = context.Request;

                if(request.RawUrl.CompareTo("/favicon.ico") == 0) // пропускать запросы favicon 
                {
                    continue;
                }

                Logger.Write("Принят HTTP-запрос: ", true, false);

                HttpListenerResponse response = context.Response;
                response.ContentEncoding = Encoding.UTF8;
                response.Headers.Add("Content-type: application/json; charset=utf-8");

                Stream output = response.OutputStream;

                JMessage message = new JMessage();

                string pathImage = request.QueryString.Get("file");

                if (pathImage is null)
                {
                    Logger.Write("не задан путь к файлу", false);
                    continue;
                }
                Image source;
                try
                {
                    source = new Bitmap(pathImage);
                }
                catch (Exception e)
                {
                    Logger.Write("неподходящий файл (скорее всего не картинка), путь = " + pathImage, false);
                    output.Close();
                    continue;
                }

                string number = yRecognizer.Recognize(source, Utility.GetAngle(settings, pathImage));
                string N = "ERR";

                if (number != null && number != "ERR")
                {
                    N = Utility.FilterO0(number, yRecognizer.PlateFound, settings.rearrangeSquare);
                }

                if(N != "ERR")
                {
                    message = new JMessage(N);
                }

                string log = pathImage + " = " + N + ", время: " + yRecognizer.recTime.ToString("%s\\.fff") + " сек.";
                byte[] buffer = message.ToBytes();
                response.ContentLength64 = buffer.Length;
                output.Write(buffer, 0, buffer.Length);
                output.Close();

                Logger.Write(log, false);
                Invoke(new ShowText(SetLabelNumberText), N );
                Invoke(new ShowText(Log), log);

                if (N != "ERR")
                {
                    Invoke(new ShowBitmap(ShowImage), yRecognizer.StageOne, PictureBoxes.Source);
                    Invoke(new ShowBitmap(ShowImage), yRecognizer.StageTwo, PictureBoxes.NumberPlate);
                }
            }

        }

        private void ListBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap source = new Bitmap(pictureDir + "\\" + listBoxPictures.SelectedItem.ToString());
            this.ShowImage(source, PictureBoxes.Source);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            pictureBoxOnlyPlate.Image.Save(@"C:\plates\" + listBoxPictures.SelectedItem.ToString(), ImageFormat.Jpeg);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settings.allowClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                notifyIcon1.Dispose();
                Logger.Write("Программа закрыта пользователем");
                System.Environment.Exit(1);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.allowClose = true;
            this.Close();
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            settings.allowClose = true;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Image src = new Bitmap(pictureDir + "\\" + listBoxPictures.SelectedItem.ToString());

            string number = yRecognizer.Recognize(src, Utility.GetAngle(settings, listBoxPictures.SelectedItem.ToString()));
            if (yRecognizer.PlateFound != PlateType.None)
            {
                pictureBoxSrc.Image = ImageProcessing.Scale(yRecognizer.StageOne, pictureBoxSrc.Width, pictureBoxSrc.Height);
                pictureBoxSrc.Invalidate();

                pictureBoxOnlyPlate.Image = ImageProcessing.Scale(yRecognizer.StageTwo, pictureBoxOnlyPlate.Width, pictureBoxOnlyPlate.Height);
                pictureBoxOnlyPlate.Invalidate();

                labelNumber.Text = Utility.FilterO0(number, yRecognizer.PlateFound, settings.rearrangeSquare);
                if (number != "ERR")
                {
                    // добавление пробела перед регионом (только для отображения)
                    labelNumber.Text = labelNumber.Text.Substring(0, 6) + " " + labelNumber.Text.Substring(6);
                }
                else
                {
                    labelNumber.Text = "ERR";
                }
            }
            else
            {
                labelNumber.Text = "ERR";
            }
        }

        private void OpenDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxPictures.Items.Clear();
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureDir = folderBrowserDialog1.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(pictureDir);
                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {
                    listBoxPictures.Items.Add(file.Name);
                }
            }
            if (listBoxPictures.Items.Count > 0) recognizeFolderToolStripMenuItem.Enabled = true;
            else recognizeFolderToolStripMenuItem.Enabled = false;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Image source = new Bitmap(openFileDialog1.FileName);
            //    pictureBoxSrc.Image = ImageProcessing.Scale(source, pictureBoxSrc.Width, pictureBoxSrc.Height);

            //    pictureBoxSrc.Invalidate();
            //}
        }

        private void ButtonRecoAll_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader headFile = new StreamReader("head.txt", true);
            string head = headFile.ReadToEnd();
            headFile.Close();
            head = head.Replace("$pictureDir$", pictureDir);
            head = head.Replace("$dateTime$", DateTime.Now.ToString("dd MMMM yyyy, HH:mm:ss"));
            head = head.Replace("$plateModelPath$", yRecognizer.yoloPlatesModel);
            head = head.Replace("$numbersModelPath$", yRecognizer.yoloNumModel);
            head = head.Replace("$plateModelLastChange$", File.GetLastWriteTime(yRecognizer.yoloPlatesModel).ToString("dd MMMM yyyy, HH:mm:ss"));
            head = head.Replace("$numbersModelLastChange$", File.GetLastWriteTime(yRecognizer.yoloNumModel).ToString("dd MMMM yyyy, HH:mm:ss"));
            head = head.Replace("$totalImages$", listBoxPictures.Items.Count.ToString());

            string reportName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            StreamWriter logFile = new StreamWriter(reportName + ".html", false, Encoding.UTF8);
            logFile.WriteLine(head);

            int good = 0;
            int plateNotFound = 0;
            int numberNotRecognized = 0;
            foreach (object i in listBoxPictures.Items)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                string trClass = "";
                string lastCell = "";
                bool notRecognized = false;
                Image src = new Bitmap(pictureDir + "\\" + i.ToString());
                string N = "Ошибка";

                string number = yRecognizer.Recognize(src, Utility.GetAngle(settings, i.ToString()));
                if (number == "ERR" && yRecognizer.PlateFound == PlateType.None) // распознавание завершилось с ошибкой и рамка номера не найдена
                {
                    notRecognized = true;
                    plateNotFound++;
                    trClass = " class=\"table-danger\"";
                    N += ": не найдена рамка номера";

                    if (!Directory.Exists(reportName))
                        Directory.CreateDirectory(reportName);

                    string newPath = reportName + "\\src_" + i.ToString().Substring(0, i.ToString().Length - 4) + "__" + Utility.RandomString(8) + ".jpg";
                    src.Save(newPath, ImageFormat.Jpeg);
                    lastCell = "<a href=\"" + newPath + "\"><img src=\"" + newPath + "\" height=\"50\"></a>";
                }
                else if (number == "ERR" && yRecognizer.PlateFound != PlateType.None) // распознавание завершилось с ошибкой, но рамка номера найдена
                {
                    notRecognized = true;
                    numberNotRecognized++;
                    trClass = " class=\"table-danger\"";
                    //N += ": " + ex.Message;
                    N += ": не распознаны символы";

                    if (!Directory.Exists(reportName))
                        Directory.CreateDirectory(reportName);

                    string newPath = reportName + "\\" + i.ToString().Substring(0, i.ToString().Length - 4) + "__" + Utility.RandomString(8) + ".jpg";
                    yRecognizer.StageTwo.Save(newPath, ImageFormat.Jpeg);
                    lastCell = "<a href=\"" + newPath + "\"><img src=\"" + newPath + "\" height=\"50\"></a>";
                }
                else
                {
                    good++;
                    N = Utility.FilterO0(number, yRecognizer.PlateFound, settings.rearrangeSquare);
                }

                if (!notRecognized)
                {
                    lastCell = Math.Round(yRecognizer.yPredSymbols.Average(item => item.Score), 4).ToString();
                }

                string log = (good+plateNotFound+numberNotRecognized).ToString() + " из " + listBoxPictures.Items.Count.ToString() + " | " + pictureDir + "\\" + i.ToString() + " = " + N + ", время: " + yRecognizer.recTime.ToString("%s\\.fff") + " сек.";
                string row = "<tr" + trClass + "><td><a href='file:///" + pictureDir + "\\" + i.ToString() + "'>" + pictureDir + "\\" + i.ToString() + "</a></td><td>" + N + "</td><td>" + yRecognizer.recTime.ToString("%s\\.fff") + " сек.</td><td>" + lastCell + "</td></tr>";

                Invoke(new ShowText(Log), log);
                logFile.WriteLine(row);
            }

            logFile.WriteLine("</table></div></div></div></body></html>");
            logFile.Close();

            StreamReader stat = new StreamReader(reportName + ".html", true);
            string fullHTML = stat.ReadToEnd();
            fullHTML = fullHTML.Replace("$recognizedImages$", good.ToString());
            fullHTML = fullHTML.Replace("$plateNotFound$", plateNotFound.ToString());
            fullHTML = fullHTML.Replace("$numbersNotRecognized$", numberNotRecognized.ToString());
            stat.Close();
            logFile = new StreamWriter(reportName + ".html", false, Encoding.UTF8);
            logFile.Write(fullHTML);
            logFile.Close();

            Invoke(new ShowText(Log), "Готово");
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void RecognizeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                recognizeFolderToolStripMenuItem.Text = "Прервать распознавание папки";
            }
            else
            {
                backgroundWorker1.CancelAsync();
                recognizeFolderToolStripMenuItem.Text = "Распознать всю папку";
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            recognizeFolderToolStripMenuItem.Text = "Распознать всю папку";
        }

        private void ButtonRecoHTTP_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "http://localhost:"+settings.HTTPport+"/?file=" + pictureDir + "\\" + listBoxPictures.SelectedItem.ToString(),
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        /////////////////////////////////////////////////
        // первая (старая) версия работы распознавания //
        /////////////////////////////////////////////////
        private void ButtonDetectPlate_Click(object sender, EventArgs e)
        {

            int[] angles = new int[] { 0, -5, 5, -10, 10, -15, 15, -20, 20 };

            Image im = new Bitmap(pictureDir + "\\" + listBoxPictures.SelectedItem.ToString());
            Image rotated = new Bitmap(im.Width, im.Height);

            List<YoloPrediction> predictions = new List<YoloPrediction>();
            foreach (int angle in angles)
            {
                rotated = ImageProcessing.Rotate(im, angle);
                predictions = yRecognizer.yPlates.Predict(rotated);
                for (int i = 0; i < predictions.Count; i++)
                {
                    if (predictions[i].Score < 0.4)
                    {
                        predictions.RemoveAt(i);
                        i--;
                    }
                }
                if (predictions.Count >= 1) break;
            }

            onlyPlate = ImageProcessing.Scale(ImageProcessing.GetRegion(rotated, predictions[0].Rectangle), 480, 300);
            pictureBoxOnlyPlate.Size = onlyPlate.Size;
            pictureBoxOnlyPlate.Image = onlyPlate;
            pictureBoxOnlyPlate.Invalidate();


            Graphics picTmp = Graphics.FromImage(rotated);
            foreach (var prediction in predictions)
            {
                Pen p = new Pen(Color.Yellow, 4);
                picTmp.DrawRectangles(p, new[] { prediction.Rectangle });
            }
            pictureBoxSrc.Image = ImageProcessing.Scale(rotated, pictureBoxSrc.Width, pictureBoxSrc.Height);

            //pictureBoxSrc.Image = rotated;
            pictureBoxSrc.Invalidate();
        }

        private void ButtonRecognize_Click(object sender, EventArgs e)
        {
            bestNumber = "";
            int[] offsets = new int[] { 0, -10, 10, -15, 15, -20, 20 };
            foreach (int offset in offsets)
            {
                string number = RecognizeNumbers(offset, 0, yRecognizer);
                if (number.Length < 8 && Math.Abs(offset) < 25)
                {
                    number = RecognizeNumbers(offset, 5, yRecognizer);
                }
                if (number.Length > bestNumber.Length)
                    bestNumber = number;
                if (number.Length >= 4)
                {
                    break;
                }
            }
            labelNumber.Text = Utility.FilterO0(bestNumber, PlateType.Rectangle, settings.rearrangeSquare);
            //labelNumber.Text = bestNumber;
        }

        private string RecognizeNumbers(int offset, int padding, YoloRecognizer yRecognizer)
        {
            Image toReco = ImageProcessing.Rotate(onlyPlate, offset);
            if (padding > 1)
            {
                toReco = ImageProcessing.GetRegion(toReco, new RectangleF(padding, padding, toReco.Width - padding, toReco.Height - padding));
            }
            pictureBoxOnlyPlate.Image = toReco;
            Thread.Sleep(50);
            yRecognizer.yNumsLetters.Predict(toReco);
            List<YoloPrediction> predictions = yRecognizer.yNumsLetters.Predict(toReco);

            for (int i = 0; i < predictions.Count; i++) // убирание того, у чего уверенность меньше 0.5
            {
                if (predictions[i].Score < 0.6)
                {
                    predictions.RemoveAt(i);
                    i--;
                }
            }

            // вычисление средней высоты символа, чтобы отделить 0 от о ///
            double avgHeight = 0;
            double midLane = 0;
            foreach (var box in predictions)
            {
                avgHeight += box.Rectangle.Height;
                midLane += box.Rectangle.Y;
            }
            avgHeight /= predictions.Count;
            midLane /= predictions.Count;
            ///////////////////////////////////////////////////////////////

            var sortedBoxesTmp = from c in predictions
                                 orderby c.Rectangle.X
                                 select c;

            List<YoloPrediction> sortedBoxes = new List<YoloPrediction>(sortedBoxesTmp);

            Graphics picTmp = Graphics.FromImage(pictureBoxOnlyPlate.Image);

            string number = "";

            double avgScore = 0;

            foreach (var box in sortedBoxes)
            {
                //if (box.Rectangle.Y < midLane)
                {
                    if (box.Label.Name == "О")
                    {
                        if (box.Rectangle.Height > avgHeight)
                            number += "0";
                        else
                            number += "О";
                    }
                    else
                    {
                        number += box.Label.Name;
                    }

                    double score = Math.Round(box.Score, 2);
                    avgScore += score;

                    picTmp.DrawRectangles(new Pen(Color.OrangeRed, 3), new[] { box.Rectangle });

                    var (x, y) = (box.Rectangle.X, box.Rectangle.Y);

                    picTmp.DrawString($"{box.Label.Name}",
                        new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.DeepPink),
                        new PointF(x, y));
                }
            }

            //foreach (var box in sortedBoxes)
            //{
            //    if (box.Rectangle.Y >= midLane)
            //    {
            //        if (box.Label.Name == "О")
            //        {
            //            if (box.Rectangle.Height > avgHeight)
            //                number += "0";
            //            else
            //                number += "О";
            //        }
            //        else
            //        {
            //            number += box.Label.Name;
            //        }

            //        double score = Math.Round(box.Score, 2);
            //        avgScore += score;

            //        picTmp.DrawRectangles(new Pen(Color.OrangeRed, 3), new[] { box.Rectangle });

            //        var (x, y) = (box.Rectangle.X, box.Rectangle.Y);

            //        picTmp.DrawString($"{box.Label.Name}",
            //            new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.DeepPink),
            //            new PointF(x, y));
            //    }
            //}


            pictureBoxOnlyPlate.Invalidate();

            avgScore /= sortedBoxes.Count;
            labelConf.Text = avgScore.ToString();

            return number;
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(ref settings);
            formSettings.ShowDialog();
        }
    }

    public enum PictureBoxes
    {
        Source,
        NumberPlate
    }
}