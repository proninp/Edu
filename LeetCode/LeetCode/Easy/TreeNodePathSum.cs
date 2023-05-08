using LeetCode.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 112. Path Sum
     * Given the root of a binary tree and an integer targetSum,
     * return true if the tree has a root-to-leaf path
     * such that adding up all the values along the path equals targetSum.
     * A leaf is a node with no children.
     */
    internal class TreeNodePathSum
    {
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            return Dfs(root, 0, targetSum);
        }
        public static bool Dfs(TreeNode root, int currSum, int target)
        {
            if (root == null)
                return false;
            currSum += root.val;
            if (root.left == null && root.right == null)
                return currSum == target;
            return Dfs(root.left, currSum, target) || Dfs(root.right, currSum, target);
        }
    }
}
