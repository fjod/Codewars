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

namespace CodeWars
{
    class Program
    {
        private static ListNode head = null;
        public static TreeNode SortedListToBST(ListNode head)
        {
            var p = head;
            var length = 0;
            while (p != null)
            {
                p = p.next;
                length++;
            }

            Program.head = head;

            return SortedListToBST(0, length);
        }

        private static TreeNode SortedListToBST(int left, int right)
        {
            if (left >= right) return null;
            var mid = left + (right - left) / 2;
            var newLeft = SortedListToBST(left, mid);
            var center = new TreeNode(head.val);
            head = head.next;
            center.left = newLeft;
            center.right = SortedListToBST(mid + 1, right);
            return center;
        }


        //inefficient tree
        public static TreeNode SortedListToBST2(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return new TreeNode(head.val);
            
            var temp = head;
            List<int> leftVals = new List<int>();
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }

            var middle = len / 2;
            head = temp;
            for (int i = 0; i < middle; i++)
            {
                leftVals.Add(head.val);
                head = head.next;
            }

            leftVals.Reverse();
            var root = new TreeNode(head.val);
            AddLeft(root, leftVals, 0);
            AddRight(root, head.next);

            return root;
        }

        private static void AddRight(TreeNode root, ListNode right)
        {
            if (right == null) return;
            var r = new TreeNode(right.val);
            root.right = r;
            AddRight(root.right, right.next);
        }

        private static void AddLeft(TreeNode root, List<int> leftVals, int i)
        {
            if (i == leftVals.Count) return;
            var left = new TreeNode(leftVals[i]);
            root.left = left;
            AddLeft(root.left, leftVals, i+1);
        }


        static void Main(string[] args)
        {
            var test = new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
            var q = SortedListToBST(test);
        }
    }
}