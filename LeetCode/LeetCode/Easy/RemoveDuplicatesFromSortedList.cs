using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /*
     * 83. Remove Duplicates from Sorted List
     * 
     * Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
     */
    public class RemoveDuplicatesFromSortedList
    {
        public static ListNode83 DeleteDuplicates(ListNode83 head)
        {
            if (head == null || head.next == null)
                return head;
            var tail = head;
            while (tail.next != null)
                if (tail.val == tail.next.val)
                    tail.next = tail.next.next;
                else
                    tail = tail.next;
            return head;
        }
    }
    public class ListNode83
    {
        public int val;
        public ListNode83 next;
        public ListNode83(int val = 0, ListNode83 next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
