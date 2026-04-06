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
        /// Note: Removes all nodes with a specific value from the linked list.
        /// To handle cases where the head node(s) need to be removed, it first advances the head pointer until it points to a node with a different value. Then, it iteratively checks subsequent nodes and skips those that match the target value.
        /// </summary>
        public ListNode RemoveElements(ListNode head, int val)
        {
            // Handle the case where the head node(s) need to be removed
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            if (head == null) return null; // If all nodes are removed
            ListNode current = head;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next; // Skip the node with the target value
                }
                else
                {
                    current = current.next; // Move to the next node
                }
            }
            return head;
        }
    }
}
