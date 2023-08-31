namespace Chapter1
{
    public class BinarySearch
    {
        public static int BinSearch(int[] array, int item)
        {
            var low = 0;
            var high = array.Length - 1;
            int mid, guess;
            while (low <= high)
            {
                mid = (low + high) / 2;
                guess = array[mid];
                if (guess == item)
                    return mid;
                if (guess > item)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return -1;
        }
    }
}
