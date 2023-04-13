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
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
           Traverse(root.left, 1);
            Traverse(root.right, 1);
            return minDepth;
        }

        private static int minDepth = int.MaxValue;
        static void Traverse(TreeNode root, int depth)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) minDepth = Math.Min(depth + 1, minDepth);
            if (root.left != null) Traverse(root.left, depth + 1);
            if (root.right != null) Traverse(root.right, depth + 1);
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