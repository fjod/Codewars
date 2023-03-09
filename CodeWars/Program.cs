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
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(DepthInner(root.left, 1), DepthInner(root.right, 1));
        }

        static int DepthInner(TreeNode node, int d)
        {
            if (node == null) return d;
            var left = DepthInner(node.left, d)+1;
            var right =DepthInner(node.right, d)+1;
            return Math.Max(left, right);
        }


        static void Main(string[] args)
        {
            // var q = InvertTree(new TreeNode{ val = 4, 
            //     left = new TreeNode { val = 2, left = new TreeNode { val = 1}, right = new TreeNode{val = 3}},
            //      right= new TreeNode { val = 7, left = new TreeNode { val = 6}, right = new TreeNode{val = 9}}});
            Console.ReadKey();
        }
    }
}