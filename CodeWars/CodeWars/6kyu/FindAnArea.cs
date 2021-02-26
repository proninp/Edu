using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication._6kyu
{
    /*
     * You have an array or list of coordinates or points (e.g. [ [1, 1], [3, 4], ... , [5, 2] ]),
     * and your task is to find the area under the graph defined by these points (limited by x of the first and last coordinates as left and right borders, y = 0 as the bottom border
     * and the graph as top border).
     * Notes:
     * x can be negative;
     * x of the next pair of coordinates will always be greater then previous one;
     * y >= 0;
     * the array will contain more than 2 coordinates.
     * Example
     * x=1 (left border)               x=5 (right border)
     * |                      x,y      |
     * |                    /\         |
     * |                   /  \        |
     * |    x,y           /    \       |
     * |   /\            /      \      |
     * |  /  \    x,y   /        \     |
     * | /    \  /\    /          \    |
     * |/      \/  \  /            \   |
     * |x,y    x,y  \/              \  |
     * |            x,y              \ | 
     * |_____________________________ \x,y_____ y=0 (bottom border)
     * The required area:
     * |                               |
     * |                    /\         |
     * |                   /\\\        |
     * |                  /\\\\\       |
     * |   /\            /\\\\\\\      |
     * |  /\\\          /\\\\\\\\\     |
     * | /\\\\\  /\    /\\\\\\\\\\\    |
     * |/\\\\\\\/\\\  /\\\\\\\\\\\\\   |
     * |\\\\\\\\\\\\\/\\\\\\\\\\\\\\\  |
     * |\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ | 
     * |\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\|____
     */

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
    public class FindAnArea
    {
        public static double FindArea(List<Point> points)
        {
            double result = 0;
            for (int i = 0; i < points.Count() - 1; i++)
                result += (points[i].Y + points[i + 1].Y) / 2 * (points[i + 1].X - points[i].X);

            //points.Zip(points.Skip(1), (p,n) => 0.5d * (n.X - p.X) * (n.Y + p.Y)).Sum();
            return result;
        }
    }

}
