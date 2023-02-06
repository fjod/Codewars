using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || n <= 0) { return null; }

            ListNode fakeHead, node1, node2;
            fakeHead = new ListNode(-1);
            fakeHead.next = head;

            node1 = node2 = fakeHead;
            for (int i = 0; i < n; i++)
            {
                if (node1 == null) { return null; }
                node1 = node1.next;
            }

            if (node1 != null)
            {
                while (node1.next != null)
                {
                    node1 = node1.next;
                    node2 = node2.next;
                }
                node2.next = node2.next.next;
            }
            return fakeHead.next;
        }

        static void Main(string[] args)
        {
             var l5 = new ListNode(5);
             var l4 = new ListNode(4, l5);
            var l3 = new ListNode(3, l4);
            var l2 = new ListNode(2, l3);
            var l1 = new ListNode(1, l2);
            RemoveNthFromEnd(l1 , 2);
            RemoveNthFromEnd(new ListNode(1), 1);
            
            RemoveNthFromEnd(new ListNode(1, new ListNode(2)), 2);
            Console.ReadKey();
        }
    }
}