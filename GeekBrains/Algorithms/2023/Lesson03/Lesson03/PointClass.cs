using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    public class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointClass(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static double PointDistanceDouble(PointClass one, PointClass two)
        {
            double x = one.X - two.X;
            double y = one.Y - two.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceFloat(PointClass one, PointClass two)
        {
            float x = one.X - two.X;
            float y = one.Y - two.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }
    }
}
