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
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
         
            List<IList<int>> ret = new List<IList<int>>();
            if (root == null) return ret;
            ret.Add(new List<int> {root.val});
            Traverse(root, ret, 1);
            if (ret.Last().Count == 0) ret.Remove(ret.Last());
            return ret;
        }

        private static void Traverse(TreeNode root, List<IList<int>> ret, int level)
        {
            if (root == null) return;
            if (ret.Count <= level) ret.Add(new List<int>());
            if (root.left != null) ret[level].Add(root.left.val);
            if (root.right != null) ret[level].Add(root.right.val);
            Traverse(root.left, ret, level + 1);
            Traverse(root.right, ret, level + 1);
        }


        static void Main(string[] args)
        {
             var q = LevelOrder(new TreeNode{ val = 3, 
                  left = new TreeNode { val = 9},
                  right= new TreeNode { val = 20, left = new TreeNode { val = 15 }, right = new TreeNode{val = 7}}});
            Console.ReadKey();
        }
    }
}