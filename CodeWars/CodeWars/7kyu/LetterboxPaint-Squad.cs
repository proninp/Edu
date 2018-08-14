﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * You and a group of friends are earning some extra money in the school holidays by re-painting the numbers on people's letterboxes for a small fee.
     * Since there are 10 of you in the group each person just concentrates on painting one digit! For example, somebody will paint only the 1's, somebody else will paint only the 2's and so on...
     * But at the end of the day you realise not everybody did the same amount of work.
     * To avoid any fights you need to distribute the money fairly. That's where this Kata comes in.
     * Kata Task
     * Given the start and end letterbox numbers, write a method to return the frequency of all 10 digits painted.
     * 
     * Example
     * For start = 125, and end = 132
     * 
     * The letterboxes are
     * 125 = 1, 2, 5
     * 126 = 1, 2, 6
     * 127 = 1, 2, 7
     * 128 = 1, 2, 8
     * 129 = 1, 2, 9
     * 130 = 1, 3, 0
     * 131 = 1, 3, 1
     * 132 = 1, 3, 2
     */
    public class LetterboxPaint_Squad
    {
        public static IEnumerable<int> PaintLetterBoxes(int start, int end)
        {
            int[] r = Enumerable.Repeat(0, 10).ToArray();
            Enumerable.Range(start, end - start + 1).ToList().ForEach(e => e.ToString().ToList().ForEach(s => r[(int)s - 48]++));
            return r.ToList();
        }
    }
}
