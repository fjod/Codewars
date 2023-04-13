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
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;
            var slow = head.next;
            var fast = head.next.next;
            while (true)
            {
                if (slow != null && fast != null && slow == fast) return true;
                if (slow.next == null) return false;
                if (fast == null) return false;
                slow = slow.next;
                if (fast.next == null) return false;
                fast = fast.next.next;
            }

        }

        

        static void Main(string[] args)
        {
            var t6 = new TreeNode {val = 6};
            var t5 = new TreeNode {val = 5, right = t6};
            var t4 = new TreeNode {val = 4, right = t5};
            var t3 = new TreeNode {val = 3, right = t4};
            var t2 = new TreeNode {val = 2, right = t3};
            MinDepth(t2);
            Console.ReadKey();
        }
    }
}