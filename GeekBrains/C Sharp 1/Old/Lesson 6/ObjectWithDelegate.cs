using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_6
{
    
    class ObjectWithDelegate
    {
        double x, y;
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public delegate double Fun(double x, double y);
        public Fun Del { get; set; }

        public ObjectWithDelegate(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public ObjectWithDelegate(double x, double y, Fun del): this(x, y) => this.Del = del;

        public void Table(double c)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= y)
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, Del(x++, c));
            Console.WriteLine("---------------------");
        }
    }
}
