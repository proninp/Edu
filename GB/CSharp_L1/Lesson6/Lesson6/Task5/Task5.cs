using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Task5
    {
        /*
         * Исполнитель:
         * Пронин Павел
         * 
         * Задание №5
         * Модифицировать задачу “Сложную задачу” ЕГЭ так, чтобы она решала задачу с 10 000 000 элементов менее чем за минуту.
         */
        static void Main(string[] args)
        {
            Save("..\\..\\Data\\Task5.bin", 1000000);
            Load2("..\\..\\Data\\Task5.bin");
            //Load("..\\..\\Data\\Task5.bin");
            Console.ReadKey();
        }
        static void Save(string fileName, int n)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 1; i < n; i++)
            {
                bw.Write(rnd.Next(0, 100000));
            }
            fs.Close();
            bw.Close();
        }
        /// <summary>
        /// Решение сложной задачи ЕГЭ из методички
        /// </summary>
        /// <param name="fileName"></param>
        static void Load(string fileName)
        {
            DateTime d = DateTime.Now;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            #region Для наглядности
            int maxElem1 = int.MinValue;
            int maxElem2 = int.MinValue;
            #endregion
            int[] a = new int[fs.Length / 4];
            for (int i = 0; i < fs.Length / 4; i++)
                a[i] = br.ReadInt32();
            br.Close();
            fs.Close();
            //int max = 0; // - max будет больше 2 * 10^9
            long max = 0;
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    //if (Math.Abs(i - j) >= 8 && a[i] * a[j] > max) // - некорректная проверка, т.к. a[i] * a[j] даст результат больше, чем умещается в тип int
                    if (Math.Abs(i - j) >= 8)
                    {
                        long m = (long)a[i] * a[j];
                        if (m > max)
                        {
                            max = m;
                            #region Для наглядности
                            maxElem1 = a[i];
                            maxElem2 = a[j];
                            #endregion
                        }
                    }
            //Console.WriteLine(max);
            Lesson6.Support.ColoredWriteLine($"Максимальное произведение элеметов {maxElem1} и {maxElem2}: {max}", ConsoleColor.Cyan);
            Console.WriteLine(DateTime.Now - d);
        }

        /// <summary>
        /// Улучшенная версия метода решения сложной задачи ЕГЭ.
        /// 1. Избавляемся от массива. Работаем только с потоком.
        /// 2. Избавляемся от вложенного цикла.
        /// 3. Избавляемся от многократных вычислений произведений во внешнем цикле.
        /// </summary>
        /// <param name="fileName">Имя файла для считывания</param>
        static void Load2(string fileName)
        {
            DateTime d = DateTime.Now;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            #region Для наглядности
            int maxElem1 = int.MinValue;
            int maxElem2 = int.MinValue;
            #endregion
            int[] a = new int[fs.Length / 4];
            long maxMulti = int.MinValue;
            int maxPrevElem = int.MinValue;
            int backPos = sizeof(int) * 9; // Возвращаемся на 9 элементов назад. Записываем значение, чтобы не вычислять каждый раз в цикле
            fs.Seek(backPos - sizeof(int), SeekOrigin.Current); // Переходим на 8 элементов вперёд, чтобы начать читать поток с элемента №9
            for (int i = 8; i < fs.Length / 4; i++)
            {
               int currentElem = br.ReadInt32();
               fs.Seek(-backPos, SeekOrigin.Current); // Возвращаемся на 9 элементов назад, т.к. в строке выше был считан элемент и позиция в потоке сдвинулась на элемент вперёд
               int prevElem = br.ReadInt32();
               if (prevElem > maxPrevElem)
                    maxPrevElem = prevElem;
                long multi = (long)maxPrevElem * currentElem;
                if (multi > maxMulti)
                {
                    maxMulti = multi;
                    #region Для наглядности
                    maxElem1 = maxPrevElem;
                    maxElem2 = currentElem;
                    #endregion
                }
                fs.Seek(backPos - sizeof(int), SeekOrigin.Current); // Возвращаемся позицию потока вперёд на 8 символов для чтения следующего значения
            }
            br.Close();
            fs.Close();
            Lesson6.Support.ColoredWriteLine($"Максимальное произведение элеметов {maxElem1} и {maxElem2}: {maxMulti}", ConsoleColor.Cyan);
            Console.WriteLine(DateTime.Now - d);
        }

    }
}
