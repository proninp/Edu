namespace Week1;

public class W1MockTest
{
    public static int FindMedian(List<int> arr)
    {
        var sorted = arr.ToArray();
        Array.Sort(sorted);
        return sorted[sorted.Length / 2];
    }
}
