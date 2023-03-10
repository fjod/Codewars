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
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            return FindSub(root, subRoot);
        }

        bool FindSub(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null) return true;
            if (root == null) return false;
            if (subRoot == null) return false;
            if (root.val == subRoot.val) 
                return CompareNodes(root, subRoot) || FindSub(root.left, subRoot) || FindSub(root.right, subRoot);
            return FindSub(root.left, subRoot) || FindSub(root.right, subRoot);
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