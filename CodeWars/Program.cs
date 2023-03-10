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
        private bool _result = true;
        public bool IsBalanced(TreeNode root)
        {
            Traverse(root);
            return _result;
        }

        int Traverse(TreeNode root)
        {
            if(root == null) {
                return -1;
            }

            var leftDepth = Traverse(root.left);
            var rightDepth = Traverse(root.right);

            _result = _result && (Math.Abs(rightDepth - leftDepth) <= 1);

            return Math.Max(leftDepth, rightDepth) + 1;
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