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
            TreeNode treeNode = new TreeNode { val = 1 };
            treeNode.left = null;
            treeNode.right = new TreeNode { val = 2 };
            treeNode.right.left = new TreeNode { val = 3 };
            treeNode.right.right = null;

            var list = BinaryTreeInorderTraversal.InorderTraversal(treeNode);
            PrintArray(list.ToArray());

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
