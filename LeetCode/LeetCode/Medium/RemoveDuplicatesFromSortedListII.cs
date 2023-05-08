using System.Collections.Generic;
using LeetCode.Common;

namespace LeetCode.Medium
{
    /*
     * 82. Remove Duplicates from Sorted List II
     * 
     * Given the head of a sorted linked list, delete all nodes that have duplicate numbers,
     * leaving only distinct numbers from the original list. Return the linked list sorted as well.
     * 
     */
    public class RemoveDuplicatesFromSortedListII
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var clone = head;
            Dictionary<int, int> distincts = new Dictionary<int, int>();
            while(clone != null)
            {
                if (distincts.ContainsKey(clone.val))
                    distincts[clone.val]++;
                else
                    distincts.Add(clone.val, 1);
                clone = clone.next;
            }
            clone = new ListNode(-1);
            head = clone;
            foreach(var pair in distincts)
                if (pair.Value == 1)
                {
                    clone.next = new ListNode(pair.Key);
                    clone = clone.next;
                }
            return head.next;
        }
    }
}
