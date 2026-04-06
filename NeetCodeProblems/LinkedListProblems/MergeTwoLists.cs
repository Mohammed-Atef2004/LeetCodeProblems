using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public partial class LinkedListProblems
    {
        /// <summary>
        /// Note: Merges two sorted linked lists using recursion.
        /// Compares current nodes and recursively links the smaller node to the remaining merged list.
        /// </summary>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
    }
}
