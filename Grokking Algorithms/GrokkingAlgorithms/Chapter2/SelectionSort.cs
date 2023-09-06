namespace Chapter2
{
    public class SelectionSort
    {
        public static void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }
    }
}
