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
        public static TreeNode  InvertTree(TreeNode root)
        {
            return InvertInner(root);
        }

        static TreeNode InvertInner(TreeNode node)
        {
            if (node == null) return node;
            var left = InvertInner(node.left);
            var right =InvertInner(node.right);
            return new TreeNode {val = node.val, left = right, right = left};
        }


        static void Main(string[] args)
        {
            var q = InvertTree(new TreeNode{ val = 4, 
                left = new TreeNode { val = 2, left = new TreeNode { val = 1}, right = new TreeNode{val = 3}},
                 right= new TreeNode { val = 7, left = new TreeNode { val = 6}, right = new TreeNode{val = 9}}});
            Console.ReadKey();
        }
    }
}