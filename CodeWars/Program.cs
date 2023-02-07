using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var n1 = Create(l1);
            var n2 = Create(l2);
            var str = (n1 + n2).ToString();
            
            var ret = new ListNode(int.Parse(str[^1].ToString()));
            var start = ret;
            for (int i = str.Length - 2; i >=0; i--)
            {
                var node =  new ListNode(int.Parse(str[i].ToString()));
                ret.next = node;
                ret = node;
            }

            return start;
        }

        private static BigInteger Create(ListNode l1)
        {
            var node = l1;
            BigInteger ret = 0;
            BigInteger counter = 1;
            while (node != null)
            {
                ret += counter * node.val;
                counter *= 10;
                node = node.next;
            }

            return ret;
        }
        static void Main(string[] args)
        {
            var l1_3 = new ListNode(3);
            var l1_2 = new ListNode(4, l1_3);
            var l1_1 = new ListNode(2, l1_2);
            
            var l2_3 = new ListNode(4);
            var l2_2 = new ListNode(6, l2_3);
            var l2_1 = new ListNode(5, l2_2);

            var l3 = new ListNode(9);
            var l4 = new ListNode(1,
                new ListNode(9,
                    new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))));

            var q = AddTwoNumbers(l3, l4);
            Console.ReadKey();
        }
    }
}