using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3;

/*
 * Subarray Division 2
 * 
 * Two children, Lily and Ron, want to share a chocolate bar. Each of the squares has an integer on it.
 * Lily decides to share a contiguous segment of the bar selected such that:
 * The length of the segment matches Ron's birth month, and,
 * The sum of the integers on the squares is equal to his birth day.
 * Determine how many ways she can divide the chocolate.
 * 
 * Function Description
 * Complete the Birthday function in the editor below.
 * Birthday has the following parameter(s):
 *  int s[n]: the numbers on each of the squares of chocolate
 *  int d: Ron's birth day
 *  int m: Ron's birth month
 * Returns
 *  int: the number of ways the bar can be divided
 */

public class SubarrayDivision2Task
{
    public static int Birthday(List<int> s, int d, int m)
    {
        int ways = 0;
        if (s.Count < m)
            return ways;
        int segmentSum = 0, left = 0, right = 0;
        for (int i = 0; i < s.Count; i++)
        {
            segmentSum += s[i];
            right++;
            if (right - left == m)
            {
                if (segmentSum == d)
                    ways++;
                segmentSum -= s[left];
                left++;
            }
        }
        return ways;
    }
}
