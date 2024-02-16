package week1;

import java.util.List;

/**
 * Subarray Division 1
 * <p>
 * Two children, Lily and Ron, want to share a chocolate bar. Each of the squares has an integer on it.
 * Lily decides to share a contiguous segment of the bar selected such that:
 * The length of the segment matches Ron's birth month, and,
 * The sum of the integers on the squares is equal to his birthday.
 * Determine how many ways she can divide the chocolate.
 * <p>
 * Function Description
 * Complete the Birthday function in the editor below.
 * Birthday has the following parameter(s):
 *  int s[n]: the numbers on each of the squares of chocolate
 *  int d: Ron's birthday
 *  int m: Ron's birth month
 * Returns
 *  int: the number of ways the bar can be divided
 */
public class SubarrayDivision1 {
    public static int birthday(List<Integer> s, int d, int m) {
        int ways = 0, segmentSum = 0, left = 0;
        for (int right = 0; right < s.size(); right++) {
            segmentSum += s.get(right);
            if (right + 1 > m) {
                segmentSum -= s.get(left);
                left++;
            }
            if (right + 1 - left == m && segmentSum == d)
                ways++;
        }
        return ways;
    }
}
