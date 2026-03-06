using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
    public class LinkedListProblems
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
        /// <summary>
        ///Note: Finds the middle node of a linked list.
        ///Determines the length of the list first, then calculates the middle index and traverses to that node.
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
            if (length == 0) return null;// Edge case: empty list
            int mid = length / 2;

            while (mid > 0)
            {
                head = head.next;
                mid--;
            }
            return head;

        }
        /// <summary>
        ///Note: Checks if a linked list is a palindrome.
        ///Due to the singly linked nature, it first stores values in a list, then uses two pointers to compare from both ends.
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
    /// <summary>
    /// Note: Implementation of a singly linked list with basic operations.
    /// </summary>
    public class MyLinkedList
    {
        private class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val)
            {
                this.val = val;
                this.next = null;
            }
        }

        private ListNode head;
        private int size;

        public MyLinkedList()
        {
            head = null;
            size = 0;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;

            ListNode temp = head;

            for (int i = 0; i < index; i++)
                temp = temp.next;

            return temp.val;
        }

        public void AddAtHead(int val)
        {
            ListNode node = new ListNode(val);
            node.next = head;
            head = node;
            size++;
        }

        public void AddAtTail(int val)
        {
            ListNode node = new ListNode(val);

            if (head == null)
            {
                head = node;
            }
            else
            {
                ListNode temp = head;
                while (temp.next != null)
                    temp = temp.next;

                temp.next = node;
            }

            size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > size)
                return;

            if (index <= 0)
            {
                AddAtHead(val);
                return;
            }

            if (index == size)
            {
                AddAtTail(val);
                return;
            }

            ListNode node = new ListNode(val);
            ListNode temp = head;

            for (int i = 0; i < index - 1; i++)
                temp = temp.next;

            node.next = temp.next;
            temp.next = node;

            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
                return;

            if (index == 0)
            {
                head = head.next;
            }
            else
            {
                ListNode temp = head;

                for (int i = 0; i < index - 1; i++)
                    temp = temp.next;

                temp.next = temp.next.next;
            }

            size--;
        }
    }
}
