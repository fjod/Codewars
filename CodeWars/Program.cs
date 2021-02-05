using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeWars
{
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
    }
    class Program
    {
        private static bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;
            List<ListNode> nodes = new List<ListNode>();
            ListNode current = head;
            do
            {
                nodes.Add(current);
                current = current.next;
            } while (current != null);

            if (nodes.Count <= 1) return true;
            //enumerated all nodes
            bool CheckTwoNodes(ListNode left, ListNode right)
            {
                if ((left == null) || (right == null)) return false;
                return left.val == right.val;
            }

            for (int i = 0; i < nodes.Count/2; i++)
            {
                var check = CheckTwoNodes(nodes[i], nodes[nodes.Count-i-1]);
                if (!check) return false;
            }

            return true;
        }
        
        static void Main(string[] args)
        {
            ListNode one = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            var ret = IsPalindrome(one);
            Console.ReadKey();
        }
    }
}
