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
        /// Note: Removes duplicates from a sorted linked list.
        /// Due to the sorted nature, duplicates will be adjacent. The method iteratively skips over duplicate nodes.
        /// </summary>
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;
            while (current != null && current.next != null)
            {
                if(current.val == current.next.val)
                {
                    current.next = current.next.next; // Skip duplicate
                }
                else
                {
                    current = current.next; // Move to next distinct value
                }
            }
            return head;
        }
    }
}
