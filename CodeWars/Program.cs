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
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return CompareNodes(p, q);
        }

        bool CompareNodes(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null) return false;
            if (q == null) return false;
            if (p.val != q.val) return false;
            return CompareNodes(p.left, q.left) && CompareNodes(p.right, q.right);
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