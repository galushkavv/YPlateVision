using System.Collections.Generic;
using Yolov5Net.Scorer;

namespace YPlateVision
{
    /// <summary>
    /// Класс, описывающий модель Yolov5 для обнаружения рамок номеров
    /// </summary>
    public class YModelPlates : Yolov5Net.Scorer.Models.Abstract.YoloModel
    {
        public override int Width { get; set; } = 640;
        public override int Height { get; set; } = 640;
        public override int Depth { get; set; } = 5; // не влияет

        public override int Dimensions { get; set; } = 7; // 5 + количество классов

        public override int[] Strides { get; set; } = new int[] { 8, 16, 32 }; // не влияет

        public override int[][][] Anchors { get; set; } = new int[][][] // не влияет
        {
            new int[][] { new int[] { 010, 13 }, new int[] { 016, 030 }, new int[] { 033, 023 } },
            new int[][] { new int[] { 030, 61 }, new int[] { 062, 045 }, new int[] { 059, 119 } },
            new int[][] { new int[] { 116, 90 }, new int[] { 156, 198 }, new int[] { 373, 326 } }
        };

        public override int[] Shapes { get; set; } = new int[] { 80, 40, 20 }; // не влияет

        public override float Confidence { get; set; } = 0.20f;
        public override float MulConfidence { get; set; } = 0.25f;
        public override float Overlap { get; set; } = 0.45f;

        public override string[] Outputs { get; set; } = new[] { "output" };

        public override List<YoloLabel> Labels { get; set; } = new List<YoloLabel>()
            {
                new YoloLabel { Id = 0, Name = "LPrus"},
                new YoloLabel { Id = 1, Name = "SqPlate"}
            };

        public override bool UseDetect { get; set; } = true;

        public YModelPlates()
        {

        }
    }

    /// <summary>
    /// Класс, описывающий модель Yolov5 для обнаружения цифр и букв в номере
    /// </summary>
    public class YModelNumbers : Yolov5Net.Scorer.Models.Abstract.YoloModel
    {
        public override int Width { get; set; } = 480;
        public override int Height { get; set; } = 480;
        public override int Depth { get; set; } = 3;

        public override int Dimensions { get; set; } = 26; // 5 + количество классов

        public override int[] Strides { get; set; } = new int[] { 8, 16, 32 };

        public override int[][][] Anchors { get; set; } = new int[][][]
        {
            new int[][] { new int[] { 010, 13 }, new int[] { 016, 030 }, new int[] { 033, 023 } },
            new int[][] { new int[] { 030, 61 }, new int[] { 062, 045 }, new int[] { 059, 119 } },
            new int[][] { new int[] { 116, 90 }, new int[] { 156, 198 }, new int[] { 373, 326 } }
        };

        public override int[] Shapes { get; set; } = new int[] { 80, 40, 20 };

        public override float Confidence { get; set; } = 0.20f;
        public override float MulConfidence { get; set; } = 0.25f;
        public override float Overlap { get; set; } = 0.45f;

        public override string[] Outputs { get; set; } = new[] { "output" };

        public override List<YoloLabel> Labels { get; set; } = new List<YoloLabel>()
            {
                new YoloLabel { Id = 0, Name = "А" },
                new YoloLabel { Id = 1, Name = "В" },
                new YoloLabel { Id = 2, Name = "С" },
                new YoloLabel { Id = 3, Name = "Е" },
                new YoloLabel { Id = 4, Name = "Н" },
                new YoloLabel { Id = 5, Name = "К" },
                new YoloLabel { Id = 6, Name = "М" },
                new YoloLabel { Id = 7, Name = "О" },
                new YoloLabel { Id = 8, Name = "Р" },
                new YoloLabel { Id = 9, Name = "Т" },
                new YoloLabel { Id = 10, Name = "Х" },
                new YoloLabel { Id = 11, Name = "У" },
                new YoloLabel { Id = 12, Name = "1" },
                new YoloLabel { Id = 13, Name = "2" },
                new YoloLabel { Id = 14, Name = "3" },
                new YoloLabel { Id = 15, Name = "4" },
                new YoloLabel { Id = 16, Name = "5" },
                new YoloLabel { Id = 17, Name = "6" },
                new YoloLabel { Id = 18, Name = "7" },
                new YoloLabel { Id = 19, Name = "8" },
                new YoloLabel { Id = 20, Name = "9" }
            };

        public override bool UseDetect { get; set; } = true;

        public YModelNumbers()
        {

        }
    }
}
