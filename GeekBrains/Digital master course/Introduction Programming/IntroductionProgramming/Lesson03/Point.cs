using System;
namespace Lesson03
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static double GetPointsDistance(Point p1, Point p2) {
            double x = Math.Pow((p2.X - p1.X), 2);
            double y = Math.Pow((p2.Y - p1.Y) ,2);
            double z = Math.Pow((p2.Z - p1.Z) ,2);
            return Math.Sqrt(x + y + z);
        }
            
        public override string ToString() => $"[{X}, {Y}, {Z}]";
    }
}