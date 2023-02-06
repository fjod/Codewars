using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;
            var current = head;
            while (current.next != null)
            {
                var next = current.next;
                if (current.val == next.val)
                {
                    while (next != null && current.val == next.val)
                    {
                        next = next.next;
                    }
                    current.next = next == null ? null : next;
                    current = next;
                    if (current == null) break;
                }
                else
                    current = next;
            }

            return head;
        }

        static void Main(string[] args)
        {
             var l3 = new ListNode(3);
             var l31 = new ListNode(3, l3);
            var l2 = new ListNode(2, l31);
            var l11 = new ListNode(1, l2);
            var l1 = new ListNode(1, l11);
            DeleteDuplicates(l1);
            Console.ReadKey();
        }
    }
}