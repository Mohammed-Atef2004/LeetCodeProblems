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
        /// Note: Finds the middle node of a linked list.
        /// Determines the length of the list first, then calculates the middle index and traverses to that node.
        /// </summary>
        public ListNode MiddleNode(ListNode head)
        {
            int length = 0;
            ListNode current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            if (length == 0) return null; // Edge case: empty list
            int mid = length / 2;

            while (mid > 0)
            {
                head = head.next;
                mid--;
            }
            return head;
        }
    }
}
