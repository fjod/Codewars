using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var l2 = new ListNode(2);

            var test = new ListNode(1, new ListNode(2));
            Console.Write(1);
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            if (head.next == null)
            {
                return false;
            }

            ListNode fast = head.next, slow = head;

            while (fast != slow)
            {
                if (fast == null || fast.next == null)
                    return false;
                fast = fast.next.next;
                slow = slow.next;
            }

            return true;
        }
    }
}