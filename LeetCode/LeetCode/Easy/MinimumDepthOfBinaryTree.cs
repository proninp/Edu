using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 111. Minimum Depth of Binary Tree
     * Given a binary tree, find its minimum depth.
     * The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
     * Note: A leaf is a node with no children.
     */
    internal class MinimumDepthOfBinaryTree
    {
        public static int MinDepth(TreeNode root)
        {
            int[] turrn = new int[2];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while ((turrn[0] == 0 || turrn[1] == 0) && queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    turrn[0]++;
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    turrn[1]++;
                }
            }
            int result = 1;
            if (turrn[0] != 0 && turrn[1] != 0)
                result += Math.Min(turrn[0], turrn[1]);
            else
                result += (turrn[0] != 0) ? turrn[0] : turrn[1];
            return result;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
