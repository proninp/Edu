﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    public class Two_Sum
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            return SecondSolution(nums, target);
        }
        public static int[] FirstSolution(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int diff = target - nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
            }
            return new int[2];
        }
        public static int[] SecondSolution(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.TryGetValue(complement, out int j))
                    return new int[] { i, j };
                map[nums[i]] = i;
            }
            return null;
        }
    }
}
