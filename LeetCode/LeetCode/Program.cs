using LeetCode.Easy;
using LeetCode.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            TreeNode root2 = new TreeNode(2);
            root2.right = new TreeNode(3);
            root2.right.right = new TreeNode(4);
            root2.right.right.right = new TreeNode(5);
            root2.right.right.right.right = new TreeNode(6);

            TreeNode root3 = new TreeNode(1);
            root3.left = new TreeNode(2);
            root3.right = new TreeNode(3);
            root3.left.left = new TreeNode(4);
            root3.right.left = new TreeNode(5);

            Console.WriteLine(MinimumDepthOfBinaryTree.MinDepth(root));
            Console.WriteLine(MinimumDepthOfBinaryTree.MinDepth(root2));
            Console.WriteLine(MinimumDepthOfBinaryTree.MinDepth(root3));
            Console.ReadLine();
        }
        static string PrintArray(int[] a)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            foreach (var e in a)
            {
                if (stringBuilder.Length > 1)
                    stringBuilder.Append(", ");
                stringBuilder.Append(string.Format($"{e}", e.ToString()));
            }
            stringBuilder.Append("]");
            Console.WriteLine(stringBuilder.ToString());
            return stringBuilder.ToString();
        }
        static void PrintList(ListNode listNode)
        {
            if (listNode == null)
                Console.WriteLine("[]");
            ListNode current = listNode;
            while(current != null)
            {
                Console.Write($"[{current.val}] ");
                current = current.next;
            }    
        }
    }
}
