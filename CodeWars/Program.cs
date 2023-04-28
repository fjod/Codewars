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
        
        public TreeNode SortedArrayToBST(int[] nums)
        {

            return SortedArrayToBST(0, nums.Length, nums);
        }

        private TreeNode SortedArrayToBST(int left, int right, int[] nums)
        {
            if (left >= right) return null;
            var mid = left + (right - left) / 2;
            var root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBST(left, mid, nums);
            root.right = SortedArrayToBST(mid + 1, right, nums);
            return root;
        }


        static void Main(string[] args)
        {
            var test = new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))));
            var q = SortedListToBST(test);
        }
    }
}