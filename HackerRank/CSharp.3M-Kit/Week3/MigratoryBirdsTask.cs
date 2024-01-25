namespace Week3;

/*
 * Migratory Birds
 * 
 * Given an array of bird sightings where every element represents a bird type id, determine the id of the most
 * frequently sighted type. If more than 1 type has been spotted that maximum amount, return the smallest of their ids.
 * 
 * Function Description
 * Complete the MigratoryBirds function in the editor below.
 * MigratoryBirds has the following parameter(s):
 *  int arr[n]: the types of birds sighted
 * Returns
 *  int: the lowest type id of the most frequently sighted birds
 * Input Format
 * The first line contains an integer, n, the size of arr.
 * The second line describes arr as n space-separated integers, each a type number of the bird sighted.
 */

public class MigratoryBirdsTask
{
    public static int MigratoryBirds(List<int> arr)
    {
        var map = new Dictionary<int, int>();
        foreach (var item in arr)
        {
            if (!map.ContainsKey(item))
                map[item] = 0;
            map[item]++;
        }
        int maxFreqValue = 0, maxFreqKey = map.Count;
        return map.OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .First().Key;
    }
}
