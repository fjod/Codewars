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
        
        public static int MinNumber(int[] nums1, int[] nums2)
        {
            var checkSame = nums1.Where(nums2.Contains);
            if (checkSame.Any()) return checkSame.Min();
            var minLeft = nums1.Min();
            var minRight = nums2.Min();
            var v1 = minLeft * 10 + minRight;
            var v2 = minLeft + 10* minRight;
            return minLeft != minRight ? Math.Min(v1, v2) : minLeft;
        }


        static void Main(string[] args)
        {
            TreeNode five = new TreeNode {val = 5};
            TreeNode two = new TreeNode {val = 2, right = five};
            TreeNode three = new TreeNode {val = 3};
            TreeNode one = new TreeNode {val = 1, left = two, right = three};
            var test = BinaryTreePaths(one);
            Console.ReadKey();
        }
    }
}