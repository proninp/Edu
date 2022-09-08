using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_3
{
    public class Complex
    {
        double im;
        double re;

        public double Im { get => im; set => im = value; }
        public double Re { get => re; set => re = value; }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        
        public Complex Plus(Complex x) => new Complex(Re + x.Re, Im + x.Im);

        public Complex Multi(Complex x) => new Complex(Re * x.Re - Im * x.Im, Re * x.Im + Im * x.Re);

        public Complex Subtraction(Complex x) => new Complex(Re - x.Re, Im - x.Im);

        public override string ToString()
        {
            if (im < 0)
                return ($"{re} - {Math.Abs(im)}i");
            if (im > 0)
                return ($"{re} + {im}i");
            return ($"{re}");
        }
        public static void Demosntrate()
        {
            string message = "Enter the real part of the first number:";
            double re = Additional.GetDoubleNumber(message);
            message = "Enter the imaginary part of the first number:";
            double im = Additional.GetDoubleNumber(message);
            Complex c1 = new Complex(re, im);
            Console.WriteLine($"Your first complex number is: {c1}");
            
            message = "Enter the real part of the second number:";
            re = Additional.GetDoubleNumber(message);
            message = "Enter the imaginary part of the second number:";
            im = Additional.GetDoubleNumber(message);
            Complex c2 = new Complex(re, im);
            Console.WriteLine($"Your second complex number is: {c2}\n");

            Console.WriteLine($"The sum of two complex numbers is: {c1.Plus(c2)}");
            Console.WriteLine($"The substraction of two complex numbers is: {c1.Subtraction(c2)}");
            Console.WriteLine($"The multiplication of two complex numbers is: {c1.Multi(c2)}");
        }
    }
}
