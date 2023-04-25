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
using System.Text;

namespace CodeWars
{
    class Program
    {
        public ListNode Partition(ListNode head, int x)
        {
            List<ListNode> smaller = new List<ListNode>();
            List<ListNode> higher = new List<ListNode>();
            while (head != null)
            {
                if (head.val < x) smaller.Add(head);
                else higher.Add(head);
                head = head.next;
            }
          

            ListNode result = new ListNode();
            ListNode temp = result;
            foreach (var item in smaller)
            {
                temp.next = item;
                temp = temp.next;
            }

            foreach (var item in higher)
            {
                temp.next = item;
                temp = temp.next;
            }

            temp.next = null;
            
            return result.next;
        }

        static void Main(string[] args)
        {
                var p = new Program();
            var result = p.Partition(new ListNode(1, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(5, new ListNode(2)))))), 3);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}