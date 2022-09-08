using System;

namespace Lesson1
{
    /*
     * Lesson 1 Home Work
     * Simple Algorithms
     * by Pronin P.S.
     */
    class Program
    {
        struct Point
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            //Task3a();
            Task3b();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
            Task11();
            Task12();
            Task13a();
            Task13b();
            Task14();
        }
        /// <summary>
        /// 1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h);
        /// где m-масса тела в килограммах, h - рост в метрах.
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Задание №1");
            Console.WriteLine("Введите свой вес в килограммах:");
            float w;
            while(!float.TryParse(Console.ReadLine(), out w))
                Console.WriteLine("Некорректный ввод!");
            Console.WriteLine("Введите свой рост в метрах (разделитель - запятая):");
            float h;
            while (!float.TryParse(Console.ReadLine(), out h))
                Console.WriteLine("Некорректный ввод!");
            Console.WriteLine($"Индекс массы тела = {w / (h * h):F}");

            Console.ReadLine();
        }
        /// <summary>
        /// 2. Найти максимальное из четырех чисел. Массивы не использовать.
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Задание №2");

            Console.WriteLine("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите четвертое число: ");
            int d = int.Parse(Console.ReadLine());

            if (a > b && a > c && a > d) Console.WriteLine("Максимальное число: {0}", a);
            if (b > a && b > c && b > d) Console.WriteLine("Максимальное число: {0}", b);
            if (c > b && c > a && c > d) Console.WriteLine("Максимальное число: {0}", c);
            if (d > b && d > c && d > a) Console.WriteLine("Максимальное число: {0}", d);

            Console.ReadLine();
        }
        /// <summary>
        /// 3. Написать программу обмена значениями двух целочисленных переменных:
        /// a.с использованием третьей переменной;
        /// </summary>
        static void Task3a()
        {
            Console.WriteLine("Задание №3(a)");
            Console.WriteLine("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("Первое число {0}, второе число {1}", a, b);
            Console.ReadLine();
        }
        /// <summary>
        /// 3. Написать программу обмена значениями двух целочисленных переменных:
        /// b. *без использования третьей переменной.
        /// </summary>
        static void Task3b()
        {
            Console.WriteLine("Задание №3(b)");
            Console.WriteLine("Введите первое число:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int b = int.Parse(Console.ReadLine());
            a += b;
            b = a - b;
            a -= b;
            Console.WriteLine("Первое число {0}, второе число {1}", a, b);
            Console.ReadLine();
        }
        /// <summary>
        /// 4. Написать программу нахождения корней заданного квадратного уравнения.
        /// </summary>
        static void Task4()
        {
            Console.WriteLine("Задание №4");
            Console.WriteLine("Введите аргумент а:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите аргумент b:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите аргумент c:");
            int c = int.Parse(Console.ReadLine());
            if (a == 0)
                Console.WriteLine("Уравнение имеет один корень: {0}", (float) (-c) / b);
            else
            {
                int d = b * b - 4 * a * c;
                if (d < 0) Console.WriteLine("Корней нет!");
                if (d == 0) Console.WriteLine("Уравнение имеет один корень: {0}", (float) ((-b) / 2 / a));
                if (d > 0) Console.WriteLine("Уравнение имеет два корня: x1 = {0}, x2 = {1}", 
                    ((-b) + Math.Sqrt(d)) / 2 / a, 
                    ((-b) - Math.Sqrt(d)) / 2 / a);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 5. С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
        /// </summary>
        static void Task5()
        {
            Console.WriteLine("Задание №5");
            Console.WriteLine("Введите номер месяца:");
            int a = int.Parse(Console.ReadLine());
            if (a < 1 || a > 12) Console.WriteLine("Некорректный ввод!");
            else if (a > 2 && a < 6) Console.WriteLine("Весна!");
            else if (a > 5 && a < 9) Console.WriteLine("Лето!");
            else if (a > 8 && a < 12) Console.WriteLine("Осень!");
            else Console.WriteLine("Зима!");
            Console.ReadLine();
        }
        /// <summary>
        /// 6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».
        /// </summary>
        static void Task6()
        {
            Console.WriteLine("Задание №6");
            Console.WriteLine("Введите аозраст от 1 до 150 лет:");
            int a = int.Parse(Console.ReadLine());
            if (a < 1 || a > 150) Console.WriteLine("Некорректный ввод!");
            else
            {
                int d = (a > 100) ? a % 100 : a;
                if (d % 10 == 1 && d != 11) Console.WriteLine("{0} год", a);
                else if ((d % 10 == 2 || d % 10 == 3 || d % 10 == 4) && !(d > 11 && d < 15)) Console.WriteLine("{0} года", a);
                else Console.WriteLine("{0} лет", a);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 7. С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1,y1,x2,y2).
        /// Требуется определить, относятся ли к поля к одному цвету или нет.
        /// </summary>
        static void Task7()
        {
            Console.WriteLine("Задание №7");
            Point p1, p2;
            Console.WriteLine("Введите x1:");
            p1.x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите y1:");
            p1.y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите x2:");
            p2.x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите y2:");
            p2.y = int.Parse(Console.ReadLine());
            Console.WriteLine("Точки [{0}, {1}] и [{2}, {3}] одного цвета: {4}", p1.x, p1.y, p2.x, p2.y, (p1.x % 2 == p1.y % 2) == (p2.x % 2 == p2.y % 2));
            Console.ReadLine();
        }
        /// <summary>
        /// 8. Ввести a и b и вывести квадраты и кубы чисел от a до b.
        /// </summary>
        static void Task8()
        {
            Console.WriteLine("Задание №8");
            Console.WriteLine("Введите a:");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine("Введите b:");
            long b = long.Parse(Console.ReadLine());
            if (a > b) Console.WriteLine("Число {0} > {1}, нечего выводить.", a, b);
            while (a <= b)
            {
                Console.WriteLine("{0}^2 = {1};\t{0}^3 = {2}", a, a*a, a*a*a);
                a++;
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 9. Даны целые положительные числа N и K.
        /// Используя только операции сложения и вычитания, найти частное от деления нацело N на K, а также остаток от этого деления.
        /// </summary>
        static void Task9()
        {
            Console.WriteLine("Задание №9");
            Console.WriteLine("Введите N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите K:");
            int k = int.Parse(Console.ReadLine());
            int rem = n;
            int qtnt = 0;
            while (rem >= k && k != 0)
            {
                rem -= k;
                qtnt++;
            }
            if (n < k) Console.WriteLine("{0} меньше {1}, частное равно 0!", n, k);
            else if (k == 0) Console.WriteLine("Входные данные не удовлтворяют условию задачи!");
            else Console.WriteLine("Частное от деления нацело {0} на {1} = {2}, остаток от деления = {3}.", n, k, qtnt, rem);
            Console.ReadLine();
        }
        /// <summary>
        /// 10. Дано целое число N (> 0). С помощью операций деления нацело и взятия остатка от деления определить,
        /// имеются ли в записи числа N нечетные цифры.
        /// Если имеются, то вывести True, если нет — вывести False.
        /// </summary>
        static void Task10()
        {
            Console.WriteLine("Задание №10");
            Console.WriteLine("Введите N:");
            int n = int.Parse(Console.ReadLine());
            bool isEven = false;
            while (!isEven && n > 0)
            {
                isEven = ((n % 10) % 2 == 0);
                n /= 10;
            }
            Console.WriteLine(isEven);
            Console.ReadLine();
        }
        /// <summary>
        /// 11. С клавиатуры вводятся числа, пока не будет введен 0.
        /// Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.
        /// </summary>
        static void Task11()
        {
            Console.WriteLine("Задание №11");
            int a, sum = 0, count = 0;
            do
            {
                Console.WriteLine("Введите число (выход - 0):");
                a = int.Parse(Console.ReadLine());
                if (a % 10 == 8)
                {
                    sum += a;
                    count++;
                }
            } while (a != 0);
            Console.WriteLine("Сумма = {0}, Среднее = {1}", sum, count == 0 ? 0 :(float) sum/count);
            Console.ReadLine();
        }
        /// <summary>
        /// 12. Написать функцию нахождения максимального из трех чисел.
        /// </summary>
        static void Task12()
        {
            Console.WriteLine("Задание №12");
            Console.WriteLine("Введите число 1:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число 2:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число 3:");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Максимальное число = {0}", (a > b && a > c) ? a : (b > a && b > c) ? b : c);
            Console.ReadLine();
        }
        /// <summary>
        /// Написать функцию, генерирующую случайное число от 1 до 100.
        /// с использованием стандартной функции rand()
        /// </summary>
        static void Task13a()
        {
            Console.WriteLine("Задание №13(a)");
            int i = 100;
            Random r = new Random();
            while(i-- > 0)
                Console.Write(r.Next(1, 101) + " ");
            Console.ReadLine();
        }
        /// <summary>
        /// Написать функцию, генерирующую случайное число от 1 до 100.
        /// без использования стандартной функции rand()
        /// </summary>
        static void Task13b()
        {
            Console.WriteLine("Задание №13(b)");
            int maxRange = 100;
            int rand = DateTime.Now.Second + 1;
            int j = 3;
            for (int i = 0; i < 100; i++)
            {
                rand = ((3 * (rand + DateTime.Now.Millisecond) << 1) % maxRange) + 1;
                Console.Write(rand + " ");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 14. * Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.
        /// Например, 25 \ :sup: 2 = 625. Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа,
        /// не превосходящие N. Записывайте в начало программы условие и свою фамилию.
        /// </summary>
        static void Task14()
        {
            Console.WriteLine("Задание №14");
            Console.WriteLine("Введите число:");
            int a = int.Parse(Console.ReadLine());
            bool isAny = false;
            for (int i = 5; i <= a; i++)
            {
                if (IsAutomorphic(i))
                {
                    if (!isAny) Console.WriteLine("Автоморфные числа: ");
                    Console.Write(i + " ");
                    isAny = true;
                }
            }
            if (!isAny) Console.WriteLine("Нет автоморфных чисел, не превосходящих {0}", a);
            Console.ReadLine();
        }
        static bool IsAutomorphic(int a)
        {
            int s = a * a;
            while(a != 0)
            {
                if (a % 10 != s % 10) return false;
                a /= 10;
                s /= 10;
            }
            return true;
        }
    }
}
