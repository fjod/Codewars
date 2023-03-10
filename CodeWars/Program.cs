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
        private int res = -1;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Traverse(root);
            return res;
        }

        int Traverse(TreeNode root)
        {
            if (root == null) return -1;
            var left = Traverse(root.left) + 1;
            var right = Traverse(root.right) + 1;
            res = Math.Max(res, (left + right));
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