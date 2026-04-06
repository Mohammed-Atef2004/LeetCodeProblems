using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems
{
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
