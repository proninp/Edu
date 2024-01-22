namespace Week3;

/*
 * Permuting Two Arrays
 * 
 * There are two n-element arrays of integers, A and B. Permute them into some A` and B`
 * such that the relation A`[i] + B`[j] >= k holds for all i where 0 <= i < n.
 * There will be q queries consisting of A, B, and k. For each query, return YES if some
 * permutation A`,B` satisfying the relation exists. Otherwise, return NO.
 * 
 * Function Description
 * Complete the TwoArrays function in the editor below. It should return a string, either YES or NO.
 * TwoArrays has the following parameter(s):
 *  int k: an integer
 *  int A[n]: an array of integers
 *  int B[n]: an array of integers
 * Returns
 *  string: either YES or NO
 */

public class PermutingTwoArraysTask
{
    public static string TwoArrays(int k, List<int> A, List<int> B)
    {
        A.Sort((a, b) => a.CompareTo(b));
        B.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < A.Count; i++)
        {
            if (A[i] + B[i] < k)
                return "NO";
        }
        return "YES";
    }
}
