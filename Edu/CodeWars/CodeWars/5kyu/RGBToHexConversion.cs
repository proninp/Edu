using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    class RGBToHexConversion
    {
        /*
         * The rgb() method is incomplete. Complete the method so that passing in RGB decimal values will result in a hexadecimal
         * representation being returned. The valid decimal values for RGB are 0 - 255. Any (r,g,b) argument values that fall out of that range should be rounded to the closest valid value.
         * The following are examples of expected output values:
         * Rgb(255, 255, 255) # returns FFFFFF
         * Rgb(255, 255, 300) # returns FFFFFF
         * Rgb(0,0,0) # returns 000000
         * Rgb(148, 0, 211) # returns 9400D3
         */
        public static string Rgb(int r, int g, int b)
        {
            //r = (r < 0) ? 0 : (r > 255) ? 255 : r;
            //g = (g < 0) ? 0 : (g > 255) ? 255 : g;
            //b = (b < 0) ? 0 : (b > 255) ? 255 : b;            
            //return ((r.ToString("X").Length > 1) ? r.ToString("X") : "0" + r.ToString("X")) +
            //    ((g.ToString("X").Length > 1) ? g.ToString("X") : "0" + g.ToString("X")) +
            //    ((b.ToString("X").Length > 1) ? b.ToString("X") : "0" + b.ToString("X"));
            r = Math.Max(Math.Min(255, r), 0);
            g = Math.Max(Math.Min(255, g), 0);
            b = Math.Max(Math.Min(255, b), 0);
            return String.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
        }
    }
}
