using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;

            var endOfFirstHalf = EndOfFirstHalf(head);
            var secondHalf = ReverseList(endOfFirstHalf.next);

            ListNode p1 = head, p2 = secondHalf;
            var result = true;
            while (p2 != null)
            {
                if (p1.val != p2.val) return false;
                p1 = p1.next;
                p2 = p2.next;
            }

            return result;
        }

        private static ListNode EndOfFirstHalf(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        private static ListNode ReverseList(ListNode head)
        {
           // 2 -> 1 -> null
           ListNode prev = null;
           ListNode curr = head;
           while (curr != null)
           {
               var next = curr.next; //save next element (1)                 (null)
               curr.next = prev; // curr = 1 prev = null => null <- 2 1 -> null   // curr = 1, prev = 2 => null <- 2 <- 1 null
               prev = curr; // curr = 2 prev = 2         => null <- 2 1 -> null   // curr = 1 prev = 1 
               curr = next; // curr = 1 prev = 2         => null <- 2 1 -> null   // curr = null prev = 1
           }

           return prev;
        }
        
        
        static void Main(string[] args)
        {
            var l1 = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            //var l2 = new ListNode(1, new ListNode(0, new ListNode(1)));
            var z = IsPalindrome(l1);
            Console.ReadKey();
        }
    }
}