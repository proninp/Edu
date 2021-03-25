using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_4
{
    public static class Task2
    {
        public static void Go()
        {
            Task1.Go();
            PrintGo();
        }
        public static void PrintGo()
        {
            Console.WriteLine("\nTask 2.\n");
            const string FILENAME = "..\\..\\Data\\Task2Data.txt";
            int[] a = GetArrayFromFile(FILENAME);
            foreach (int el in a)
                Console.Write($"{el} ");
        }
        public static int[] GetArrayFromFile(string filename)
        {
            string arrayText = "";
            try
            {
                // for example, numbers will stand in one line with spaces as separators
                arrayText = File.ReadAllText(filename); // 10 3 4 5 6 7 8 2 3 4 5
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (arrayText.Length == 0)
                throw new Exception("String array cannot be empty.");
            string[] stringArr = arrayText.Split(' ');
            int[] array = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
                int.TryParse(stringArr[i], out array[i]);
            return array;
        }
    }
    
}