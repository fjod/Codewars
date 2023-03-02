using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;
            var prev = head; //1
            var current = prev.next; //2
            ListNode next = null;
            while (current != null)
            {
                next = current.next; // save 3
                current.next = prev; // 2 -> 1
                prev = current; // move forward, so current node is 2
                current = next; // next node is 3
            }

            head.next = null;
            return prev;
        }


        static void Main(string[] args)
        {
            var q = ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
            Console.ReadKey();
        }
    }
}