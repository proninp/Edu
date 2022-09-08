using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson05
{
    class Program
    {
        private static string internalDirectory = "Lesson05";
        public static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Console.ReadLine();
        }
        /// <summary>
        /// Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
        /// </summary>
        public static void Task1()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Введите строку:");
            string fileName = Path.Combine(GetInternalDir(), MethodBase.GetCurrentMethod().Name + ".txt");
            string input = Console.ReadLine();
            File.WriteAllText(fileName, input);
            Console.WriteLine($"Данные сохранены в файле:\n{fileName}");
        }

        /// <summary>
        /// Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
        /// </summary>
        public static void Task2()
        {
            Console.WriteLine("\nTask 2");
            string timeStamp = DateTime.Now.ToString();
            string fileName = Path.Combine(GetInternalDir(), "startup.txt");
            File.AppendAllLines(fileName, new string[] { timeStamp });
            Console.WriteLine($"В файле {fileName} записан текст:\n{File.ReadAllText(fileName)}");
        }

        /// <summary>
        /// Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
        /// </summary>
        public static void Task3()
        {
            Console.WriteLine("\nTask 3");
            Console.WriteLine("Введите числа от 0 до 255 через пробел:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return;
            byte[] numbers = input.Split(' ').ToArray().Select(x => byte.Parse(x)).ToArray();
            string fileName = Path.Combine(GetInternalDir(), MethodBase.GetCurrentMethod().Name + ".bin");
            File.WriteAllBytes(fileName, numbers);
            Console.WriteLine($"В файл {fileName} был записан массив байт:\n[{string.Join(", ", File.ReadAllBytes(fileName))}]");
        }
        
        #region Task 4
        /// <summary>
        /// Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
        /// </summary>
        public static void Task4()
        {
            Console.WriteLine("\nTask 4");

            DirectoryInfo projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            Console.WriteLine(projectDirectory.FullName);

            Console.WriteLine("Recursively");
            PrintDirRecursively(projectDirectory, "", true);
        }
        static void PrintDirRecursively(DirectoryInfo directoryInfo, string indent, bool lastDirectory)
        {
            Console.Write(indent);
            Console.Write(lastDirectory ? "└" : "├");
            indent += lastDirectory ? " " : "│ ";
            Console.WriteLine(directoryInfo.Name);
            DirectoryInfo[] subDirs = directoryInfo.GetDirectories();
            
            FileInfo[] files = directoryInfo.GetFiles();
            string fileIndent = string.Concat(indent, (directoryInfo.GetDirectories().Length > 0) ? "│ " : " ");
            foreach (var file in files)
                Console.WriteLine($"{fileIndent}[{file.Name}]");

            for (int i = 0; i < subDirs.Length; i++)
                PrintDirRecursively(subDirs[i], indent, i == subDirs.Length - 1);
        }
        #endregion

        /// <summary>
        /// Список задач (ToDo-list)
        /// </summary>
        public static void Task5()
        {
            Console.WriteLine("\nTask 5");
            string fileNameJson = Path.Combine(GetInternalDir(), MethodBase.GetCurrentMethod().Name + ".json");
            string fileNameXml = Path.Combine(GetInternalDir(), MethodBase.GetCurrentMethod().Name + ".xml");
            string fileNameBin = Path.Combine(GetInternalDir(), MethodBase.GetCurrentMethod().Name + ".bin");

            ToDo[] toDoList = new ToDo[] { new ToDo("Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.", true),
                new ToDo("Написать программу, которая при старте дописывает текущее время в файл «startup.txt».", true),
                new ToDo("Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.", true),
                new ToDo("Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией.", true),
                new ToDo("Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — без рекурсии.", false),
                new ToDo("Список задач (ToDo-list)", true),
            };
            Console.WriteLine("До сериализации:");
            foreach(var e in toDoList)
                Console.WriteLine(e);

            // Запись массива в .json
            if (!File.Exists(fileNameJson))
                File.WriteAllText(fileNameJson, JsonSerializer.Serialize(toDoList));

            // Запись массива в .xml
            if (!File.Exists(fileNameXml))
            {
                StringWriter stringWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
                serializer.Serialize(stringWriter, toDoList);
                string xml = stringWriter.ToString();
                File.WriteAllText(fileNameXml, xml);
            }
            // Запись массива в .bin
            if (!File.Exists(fileNameBin))
                new BinaryFormatter().Serialize(new FileStream(fileNameBin, FileMode.OpenOrCreate), toDoList);

            // Десериализация Json
            ToDo[] todoListJson = JsonSerializer.Deserialize<ToDo[]>(File.ReadAllText(fileNameJson));
            Console.WriteLine("\nДесериализация Json:");
            foreach(var e in todoListJson)
                Console.WriteLine(e);

            // Десериализация Xml
            string xmlText = File.ReadAllText(fileNameXml);
            StringReader stringReader = new StringReader(xmlText);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo[]));
            ToDo[] todoListXml = (ToDo[])xmlSerializer.Deserialize(stringReader);
            Console.WriteLine("\nДесериализация Xml:");
            foreach (var e in todoListXml)
                Console.WriteLine(e);

            // Бинарная десериализация
            BinaryFormatter formatter = new BinaryFormatter();
            ToDo[] todoListBinary = (ToDo[])formatter.Deserialize(new FileStream(fileNameBin, FileMode.Open));
            Console.WriteLine("\nДесериализация Binary:");
            foreach (var e in todoListBinary)
                Console.WriteLine(e);
        }

        /// <summary>
        /// Получение директории внутри проекта для записи файлов
        /// </summary>
        /// <returns>Директория</returns>
        static string GetInternalDir()
        {
            string dir = Path.Combine(Environment.CurrentDirectory, internalDirectory);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }
    }
}
