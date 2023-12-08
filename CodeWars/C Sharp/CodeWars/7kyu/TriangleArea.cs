using System;
using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Triangle area
     * 
     * Calculate area of given triangle. Create a function t_area that will take a string which will represent triangle,
     * find area of the triangle, one space will be equal to one length unit. The smallest triangle will have one length unit.
     */
    public class TriangleArea
    {
        public static double TArea(string s)
        {
            return Math.Pow(s.Split('\n').Length - 3, 2) / 2;
        }
    }
}
