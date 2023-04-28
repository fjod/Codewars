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

        public static void Flatten(TreeNode root)
        {
            if (root == null) return;
            TreeNode ret = new TreeNode(root.val);
            prev = ret;
            TraverseLeft(root.left);
            TraverseLeft(root.right);
            root.right = ret.right;
            root.left = null;
        }

        private static TreeNode prev = null;
        private static void TraverseLeft(TreeNode leaf)
        {
            if (leaf == null) return;
            prev.right = new TreeNode(leaf.val);
            prev = prev.right;
            TraverseLeft(leaf.left);
            TraverseLeft(leaf.right);
        }


        static void Main(string[] args)
        {
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node2 = new TreeNode(2, node3, node4);
            var node6 = new TreeNode(6);
            var node5 = new TreeNode(5, null, node6);
            var node1 = new TreeNode(1, node2, node5);
            Flatten(node1);
        }
    }
}