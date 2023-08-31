namespace Chapter1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Binary search
            var array = new int[] { 1, 2, 3, 5, 7, 9 };
            Console.WriteLine(BinarySearch.BinSearch(array, 3));
            Console.WriteLine(BinarySearch.BinSearch(array, 10));
            #endregion
        }
    }
}