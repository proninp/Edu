using System;

namespace Lesson_2
{
    /*
     * Pronin P.S.
     * 
     * Task 5
     * а) Write programm, that will request users weight and height and calculate body weight index.
     * б) *Calculate users normal BWI.
     */
    class Task5
    {
        public static void Go()
        {
            #region Initialization
            const int NORMAL_INDEX = 2;
            double[] indexes = new double[] {16, 18.5, 25, 30, 35, 40}; // BWI values
            string[,] stAr = new string[,] {
                { "Body weight deficit", "You need to gain weight." },
                { "Insufficient (deficit) body weight.", "You need to gain weight."},
                {"Normal bw.","Your weight is normal." },
                {"Overweight (pre-obesity).", "It would not hurt to lose weight on" },
                { "Obesity.", "Need to lose weight" },
                { "Severe obesity.", "Very urgently need to lose weight on" },
                { "Very severe obesity.", "Very urgently need to lose weight on"}
            };
            #endregion
            CommonMethods.ColoredWriteLine("Enter your weight in kilos:", ConsoleColor.Yellow);
            int w = CommonMethods.SetIntParametr();
            CommonMethods.ColoredWriteLine("Enter your height in sm:", ConsoleColor.Yellow);
            double h = CommonMethods.SetDoubleParametr() / 100;
            double index = w / (h * h);
            CommonMethods.ColoredWriteLine($"\nBWI = {index:F}", ConsoleColor.Cyan);
            for(int i = 0; i < indexes.Length; i++)
            {
                if (index < indexes[i])
                {
                    if (i == NORMAL_INDEX)
                        CommonMethods.ColoredWriteLine($"{stAr[i, 0]}\n{stAr[i, 1]}", ConsoleColor.Cyan);
                    else
                        CommonMethods.ColoredWriteLine($"{stAr[i, 0]}\n{stAr[i, 1]} {GetWeightDiff(indexes[NORMAL_INDEX-1], indexes[NORMAL_INDEX], h, w):F} kg.", ConsoleColor.Cyan);
                    break;
                } else if (i == indexes.Length - 1)
                {
                    CommonMethods.ColoredWriteLine($"{stAr[i+1, 0]}\n{stAr[i+1, 1]} {GetWeightDiff(indexes[NORMAL_INDEX - 1], indexes[NORMAL_INDEX], h, w):F} kg.", ConsoleColor.Cyan);
                }
            }
        }
        public static double GetWeightDiff(double minNormalIndex, double maxNormalIndex, double h, double w) =>
            (w / (h * h) < minNormalIndex) ? (h * h * minNormalIndex - w) : w - h * h * maxNormalIndex;
    }
}