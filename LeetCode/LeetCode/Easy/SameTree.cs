using System;
using LeetCode.Common;

namespace LeetCode.Easy
{
    /*
     * 100. Same Tree
     * 
     * Given the roots of two binary trees p and q, write a function to check if they are the same or not.
     * Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
     */
    public class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            return (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }

    }
}
