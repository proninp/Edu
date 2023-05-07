using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Common;

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
        public static int MinDepthRecoursive(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null)
                return 1 + MinDepth(root.right);
            if (root.right == null)
                return 1 + MinDepth(root.left);
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            int depth = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                depth++;
                while (size-- > 0)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left == null && node.right == null)
                        return depth;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return depth;
        }
    }
    
}
