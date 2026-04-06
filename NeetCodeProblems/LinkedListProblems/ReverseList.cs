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
        /// Note: Reverses a singly linked list.
        /// Maintains 'prev' and 'nextTemp' pointers while iterating through the list iteratively.
        /// </summary>
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode nextTemp = current.next;
                current.next = prev; // Perform reversal
                prev = current;
                current = nextTemp; // Move forward
            }
            return prev;
        }
    }
}
