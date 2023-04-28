using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    public class FunWithTreesMaxSum
    {
        /*
         * Fun with trees: max sum
         * 
         * You are given a binary tree. Implement the method maxSum which returns the maximal sum of a route from root to leaf. For example, given the following tree:
         *       17
         *      /  \
         *     3   -10
         *    /    /  \
         *   2    16   1
         *            /
         *           13
         * The method should return 23, since [17,-10,16] is the route from root to leaf with the maximal sum.
         */
        public static int MaxSum(TreeNode root)
        {
            int[] sums = new int[2];
            Traversal(root, sums);
            return sums[1];
        }
        public static void Traversal(TreeNode root, int[] sums)
        {
            if (root == null) return;
            sums[0] += root.value;
            if (root.left == null && root.right == null)
            {
                if (sums[0] > sums[1])
                    sums[1] = sums[0];
            }
            else
            {
                Traversal(root.left, sums);
                Traversal(root.right, sums);
            }
            sums[0] -= root.value;
        }
        public static int MaxSum2(TreeNode root)
        {
            return root == null ? 0 :
              root.value + Math.Max(MaxSum(root.left), MaxSum(root.right));
        }
    }
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;
    }
}
