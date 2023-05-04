using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsSameTree(TreeNode100 p, TreeNode100 q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            return (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }

    }
    public class TreeNode100
    {
        public int val;
        public TreeNode100 left;
        public TreeNode100 right;
        public TreeNode100(int val = 0, TreeNode100 left = null, TreeNode100 right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
