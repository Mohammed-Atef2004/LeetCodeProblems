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
        /// Note: Detects if a linked list contains a cycle.
        /// Employs Floyd's Cycle-Finding Algorithm (Fast and Slow pointers). 
        /// </summary>
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            ListNode slow = head;
            ListNode fast = head;

            // Fast pointer moves twice as fast; if they meet, a cycle exists
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }
    }
}
