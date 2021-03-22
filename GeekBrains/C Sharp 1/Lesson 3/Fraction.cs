using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_3
{
    class Fraction
    {
        int numerator;
        int denominator;
        int intPart;
        bool sign = true;

        public int Numerator
        {
            get => numerator;
            set
            {
                if (value < 0)
                    sign = false;
                numerator = Math.Abs(value);
            }
        }
        public int Denominator
        {
            get => denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator must not equals zero.");
                if (value < 0)
                    sign = false;
                denominator = Math.Abs(value);
            }
        }
        public int IntPart { get => intPart; }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            intPart = Numerator / Denominator;
            if (IntPart != 0)
                Numerator -= Numerator / Denominator * Denominator;
            int gcd = Additional.Gcd(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }
        void Normalize()
        {
            numerator += denominator * intPart;
            intPart = 0;
            numerator = (!sign) ? -numerator : numerator;
            sign = true;
        }
        public Fraction Sum(Fraction f)
        {
            Normalize();
            f.Normalize();
            if (Denominator == f.Denominator)
                return new Fraction(Numerator + f.Numerator, Denominator);
            int lcm = Additional.Lcm(Denominator, f.Denominator);
            return new Fraction(lcm / Denominator * Numerator + lcm / f.Denominator * f.Numerator, Denominator * lcm / Denominator);
        }
        public Fraction Substraction(Fraction f) => Sum(new Fraction(-f.Numerator, f.Denominator));
        public Fraction Multiplication(Fraction f)
        {
            Normalize();
            f.Normalize();
            return new Fraction(Numerator * f.Numerator, Denominator * f.Denominator);
        }
        public Fraction Division(Fraction f)
        {
            f.Numerator += f.Denominator * f.IntPart;
            f.intPart = 0;
            Additional.Swap(ref f.numerator, ref f.denominator);
            return Multiplication(f);
        }
        public override string ToString()
        {
            if (Numerator == 0 && IntPart == 0)
                return "0";
            if (Numerator == 0 && IntPart != 0)
                return IntPart.ToString();
            if (Denominator == 1)
                return (sign) ? Numerator.ToString() : (-Numerator).ToString();
            string signText = "";
            if (!sign)
                signText = "-";
            return $"{signText}{((IntPart != 0) ? IntPart + " point " : "")}{Numerator}/{Denominator}";
        }
        public static void Go()
        {
            string message = "Enter numerator part of the first fraction:";
            int num = Additional.GetIntegerNumber(message);
            message = "Enter denumerator part of the first fraction:";
            int denum = Additional.GetIntegerNumber(message);
            Fraction f1 = new Fraction(num, denum);
            Console.WriteLine(f1.ToString());

            message = "Enter numerator part of the second fraction:";
            num = Additional.GetIntegerNumber(message);
            message = "Enter denumerator part of the second fraction:";
            denum = Additional.GetIntegerNumber(message);
            Fraction f2 = new Fraction(num, denum);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose arithmetic action:\n +\t: Sum;\n -\t: Substraction;\n *\t: Multiply;\n /\t: Division;\n 0\t: End process.");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "+":
                        Console.WriteLine($"Sum operation result:\n{f1.Sum(f2)}");
                        break;
                    case "-":
                        Console.WriteLine($"Substraction operation result:\n{f1.Substraction(f2)}");
                        break;
                    case "*":
                        Console.WriteLine($"multiply operation result:\n{f1.Multiplication(f2)}");
                        break;
                    case "/":
                        Console.WriteLine($"Devision operation result:\n{f1.Division(f2)}");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("There is no function for that item!");
                        break;
                }
            }
            Console.ReadLine();
        }

    }
}
