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
        /// Note: Checks if a linked list is a palindrome.
        /// Due to the singly linked nature, it first stores values in a list, then uses two pointers to compare from both ends.
        /// </summary>
        public bool IsPalindrome(ListNode head)
        {
            List<int> values = new List<int>();
            ListNode current = head;
            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }
            int left = 0, right = values.Count - 1;
            while (left < right)
            {
                if (values[left] != values[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
