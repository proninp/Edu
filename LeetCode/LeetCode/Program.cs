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
            ListNode head = new ListNode(1);
            var list = head;
            list.next = new ListNode(2);
            list = list.next;

            list.next = new ListNode(3);
            list = list.next;

            list.next = new ListNode(3);
            list = list.next;

            list.next = new ListNode(4);
            list = list.next;

            list.next = new ListNode(4);
            list = list.next;

            list.next = new ListNode(5);
            list = list.next;


            list = RemoveDuplicatesFromSortedListII.DeleteDuplicates(head);
            PrintList(list);

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
