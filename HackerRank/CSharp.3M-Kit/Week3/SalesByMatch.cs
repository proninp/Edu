namespace Week3;

/*
 * Sales by Match
 * 
 * There is a large pile of socks that must be paired by color. Given an array of integers representing the color of
 * each sock, determine how many pairs of socks with matching colors there are.
 * 
 * Function Description
 * Complete the SockMerchant function in the editor below.
 * SockMerchant has the following parameter(s):
 * int n: the number of socks in the pile
 * int ar[n]: the colors of each sock
 * Returns
 * int: the number of pairs
 */

public class SalesByMatch
{
    public static int SockMerchant(int n, List<int> ar)
    {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < ar.Count; i++)
        {
            if (!map.ContainsKey(ar[i]))
                map[ar[i]] = 0;
            map[ar[i]]++;
        }
        var pairsCount = 0;
        foreach (var e in map.Values)
            pairsCount += e / 2;
        return pairsCount;
    }
}
