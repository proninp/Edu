namespace Chapter2
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Selection Sort
            var array = new int[] { 6, 12, 8, 5, 1, 9 };
            SelectionSort.SelectSort(array);
            Console.WriteLine(string.Join(", ", array));
            #endregion
        }
    }
}