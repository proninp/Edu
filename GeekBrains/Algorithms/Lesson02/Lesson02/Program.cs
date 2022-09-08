using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2(); // Сложность алгоритма = O(log n)
            Console.ReadLine();
        }
        /// <summary>
        /// Двусвязный список
        /// Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в
        /// нём в соответствии с интерфейсом.
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Task 1\n");
            Random random = new Random();
            int[] a = new int[] { 1, 5, 7, 92, 0, 3, 17, 8 };
            LinkedList linkedList = new LinkedList();
            for (int i = 0; i < a.Length; i++)
            {
                linkedList.AddNode(a[i]);
            }
            linkedList.Print("Linked List:");

            linkedList.AddNode(GetRandomValue(random, a.Length));
            linkedList.Print("After adding a Node:");

            Node node = linkedList.FindNode(a[random.Next(0, a.Length)]);
            linkedList.AddNodeAfter(node, GetRandomValue(random, a.Length));
            linkedList.Print($"After adding a node after the node with value {node.Value}:");

            int indexToRemove = random.Next(0, a.Length);
            linkedList.RemoveNode(indexToRemove);
            linkedList.Print($"After removing a node with index {indexToRemove}:");

            Console.WriteLine();
        }
        static int GetRandomValue(Random random, int basis) => (random.Next(0, basis) * random.Next(0, basis) - random.Next(0, basis));

        /// <summary>
        /// Двоичный поиск
        /// Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и
        /// проверить работоспособность функци
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("Task 2\n");
            int[] a = new int[] { -44, -15, -7, 0, 2, 14, 15, 18, 22, 40, 47, 52 };
            foreach(var el in a)
                Console.Write($"[{el}] ");
            Random random = new Random();
            int searchValue = a[random.Next(0, a.Length)];
            Console.WriteLine($"\nSearched value {searchValue} is located on {BinarySearch(a, searchValue)} index.");
            Console.WriteLine("O(log n)");
        }
        /// <summary>
        /// Binary search algorithm
        /// </summary>
        /// <param name="a">Array sorted in ascending order</param>
        /// <param name="searchValue">Searched value</param>
        /// <returns></returns>
        static int BinarySearch(int[] a, int searchValue)
        {
            int min = 0;
            int max = a.Length - 1;
            while (min <= max)
            {
                int mid = (max + min) / 2;
                if (a[mid] == searchValue)
                    return mid;
                if (searchValue > a[mid])
                    min = mid + 1;
                else
                    max = mid - 1;
            }
            return -1;
        }
    }
}
