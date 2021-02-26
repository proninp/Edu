using System.Collections.Generic;
using System.Linq;

namespace CodeWars._6kyu
{
    /*
     * Ball Upwards
     * You throw a ball vertically upwards with an initial speed v (in km per hour).
     * The height h of the ball at each time t is given by h = v*t - 0.5*g*t*t where g is Earth's gravity (g ~ 9.81 m/s**2).
     * A device is recording at every tenth of second the height of the ball. For example with v = 15 km/h
     * the device gets something of the following form: (0, 0.0), (1, 0.367...), (2, 0.637...), (3, 0.808...), (4, 0.881..) ...
     * where the first number is the time in tenth of second and the second number the height in meter.
     * Task
     * Write a function max_ball with parameter v (in km per hour) that returns the time in tenth of second of the maximum height recorded by the device.
     * Examples:
     * max_ball(15) should return 4
     * max_ball(25) should return 7
     */
    public class BallUpwards
    {
        public static int MaxBall(int v)
        {
            Dictionary<int, double> d = new Dictionary<int, double>();
            int t = 0;
            double h = 1;
            while (h > 0)
            {
                h = (double) v * 1000 / 36000 * (++t) - 0.04905 * t * t;
                d.Add(t, h);
            }
            return d.FirstOrDefault(x => x.Value == d.Max(y => y.Value)).Key;
        }
    }
}
