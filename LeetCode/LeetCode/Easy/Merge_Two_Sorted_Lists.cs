using System.Collections.Generic;
using LeetCode.Common;

namespace LeetCode.Easy
{
    /*
     * You are given the heads of two sorted linked lists list1 and list2.
     * Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
     * Return the head of the merged linked list.
     * 
     * Input: list1 = [1,2,4], list2 = [1,3,4]
     * Output: [1,1,2,3,4,4]
     * 
     * Input: list1 = [], list2 = []
     * Output: []
     */
    public class Merge_Two_Sorted_Lists
    {
        internal ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            List<int> list = new List<int>();
            while (list1 != null)
            {
                list.Add(list1.val);
                list1 = list1.next;
            }
            while (list2 != null)
            {
                list.Add(list2.val);
                list2 = list2.next;
            }
            if (list.Count == 0)
                return null;
            GFG g = new GFG();
            list.Sort(g);
            ListNode result = new ListNode(list[0]);
            ListNode resultList = result;
            for (int i = 1; i < list.Count; i++)
            {
                result.next = new ListNode(list[i]);
                result = result.next;
            }
            return resultList;
        }
    }
    class GFG : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }
    
}
