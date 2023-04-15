using System.Text;

namespace Lesson02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            DobleLinkedList dList = new DobleLinkedList();
            dList.AddNode(5);
            dList.AddNode(1);
            dList.AddNode(8);
            dList.AddNode(4);
            Console.WriteLine($"Length: {dList.Count}");
            dList.Print();
            dList.RemoveNode(1);
            Console.WriteLine("After removing element:");
            dList.Print();
            Console.WriteLine();
            Console.WriteLine("Task 2");
            int[] a = { 1, 3, 4, 5, 7, 9, 12, 14, 15, 19 };
            Console.WriteLine(BinarySearch(a, 15));
        }
        static int BinarySearch(int[] sortedArray, int searched)
        {
            int min = 0;
            int max = sortedArray.Length - 1;
            while(min <= max)
            {
                int mid = (min + max) / 2;
                if (sortedArray[mid] < searched)
                {
                    min = mid + 1;
                }
                else if (sortedArray[mid] > searched)
                    max = mid - 1;
                else
                    return mid;
            }
            return -1;

        }
    }
}