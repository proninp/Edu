using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    /*
     * Perimeter of squares in a rectangle
     * The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8.
     * It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80
     * Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing:
     * 
     * #Hint: See Fibonacci sequence
     * #Ref: http://oeis.org/A000045
     * The function perimeter has for parameter n where n + 1 is the number of squares
     * (they are numbered from 0 to n) and returns the total perimeter of all the squares.
     * perimeter(5)  should return 80
     * perimeter(7)  should return 216
     */
    public class PerimeterOfSquaresInARectangle
    {
        public static BigInteger Perimeter(BigInteger n)
        {
            Dictionary<BigInteger, BigInteger> d = new Dictionary<BigInteger, BigInteger>() { { 0, 1 }, { 1, 1 } };
            BigInteger m = 1;
            BigInteger sum = 2;
            while(++m <= n)
            {
                BigInteger prev = d[m - 1];
                BigInteger pprev = d[m - 2];
                sum += prev + pprev;
                d.Add(m, prev + pprev);
            }
            return (n == 0) ? 4 : sum * 4;
        }
    }
}
