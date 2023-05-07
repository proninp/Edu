using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Common;

namespace LeetCode.Easy
{
    /*
     * 94. Binary Tree Inorder Traversal
     * 
     * Given the root of a binary tree, return the inorder traversal of its nodes' values.
     * 
     * Example:
     * Input: root = [1,null,2,3]
     * Output: [1,3,2]
     */
    public class BinaryTreeInorderTraversal
    {
        public static IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            Traversal(list, root);
            return list;
        }
        public static void Traversal(List<int> list, TreeNode root)
        {
            if (root == null)
                return;
            Traversal(list, root.left);
            list.Add(root.val);
            Traversal(list, root.right);
        }
    }
}