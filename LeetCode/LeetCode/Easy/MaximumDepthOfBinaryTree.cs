using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Common;

namespace LeetCode.Easy
{
    /*
     * 104. Maximum Depth of Binary Tree
     * 
     * Given the root of a binary tree, return its maximum depth.
     * A binary tree's maximum depth is the number of nodes along the longest path
     * from the root node down to the farthest leaf node.
     * Edited by https://github.com/github/dev
     */
    internal class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return (1 + (Math.Max(MaxDepth(root.left), MaxDepth(root.right))));
        }
    }
}
