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
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> wayTo_p = new List<TreeNode>();
            List<TreeNode> wayTo_q = new List<TreeNode>();
            Find(root, p, wayTo_p);
            Find(root, q, wayTo_q);
            var shortest = wayTo_p.Count > wayTo_q.Count ? wayTo_p : wayTo_q;
            var longest = wayTo_p.Count < wayTo_q.Count ? wayTo_p : wayTo_q;
            if (wayTo_q.Count == wayTo_p.Count)
            {
                shortest = wayTo_p;
                longest = wayTo_q;
            }
            longest.Reverse();
            foreach (var treeNode in longest)
            {
                if (shortest.Contains(treeNode)) return treeNode;
            }

            throw new Exception("val not found");
        }

        private static void Find(TreeNode root, TreeNode treeNode, List<TreeNode> wayToP)
        {
            wayToP.Add(root);
            if (root.val == treeNode.val)
            {
                return;
            }

            if (root.val > treeNode.val)
            {
                Find(root.left, treeNode, wayToP);
            }
            if (root.val < treeNode.val)
            {
                Find(root.right, treeNode, wayToP);
            }
        }


        static void Main(string[] args)
        {
             var q = LowestCommonAncestor(new TreeNode{ val = 6, 
                  left = new TreeNode { val = 2,
                      left = new TreeNode {val = 0}, 
                      right = new TreeNode{val = 4, left = new TreeNode{val = 3}, right = new TreeNode{val = 5}}},
                  right= new TreeNode { val = 8, left = new TreeNode { val = 7 }, right = new TreeNode{val = 9}}}, new TreeNode {val = 2}, new TreeNode {val = 8});
            Console.ReadKey();
        }
    }
}