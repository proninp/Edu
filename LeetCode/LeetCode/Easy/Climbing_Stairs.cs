using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 70. Climbing Stairs
     * 
     * You are climbing a staircase. It takes n steps to reach the top.
     * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
     * 
     */
    public class Climbing_Stairs
    {
        public int ClimbStairs(int n)
        {
            if (n < 3)
                return n;
            int[] a = new int[n + 1];
            a[1] = 1;
            a[2] = 2;
            for (int i = 3; i <= n; i++)
                a[i] = a[i - 2] + a[i - 1];
            return a[n];
        }
    }
}
