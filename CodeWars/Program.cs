using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static ListNode RotateRight(ListNode head, int k)
        {

            if (head == null || k == 0 || head.next == null) return head;
            ListNode fast = head;
            ListNode slow;
            ListNode stop = null;
            for (int i = 0; i < k; i++)
            {
                fast = fast.next;
                if (fast == null)
                {
                    fast = head;
                }
            }

            if (fast == head) return head;
          
            slow = head;
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            stop = slow.next;

            fast.next = head;
            slow.next = null;
            return stop;
        }

        static void Main(string[] args)
        {
            var test = RotateRight(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);
            var test2 = RotateRight(new ListNode(1, new ListNode(2, new ListNode(3))), 2000000000);
        }
    }
}