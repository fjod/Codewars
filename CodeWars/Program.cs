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
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> ret = new List<int>();
            Traverse(root, ret);
            return ret;
        }

        private void Traverse(TreeNode root, List<int> ret)
        {
            if (root == null) return;
            Traverse(root.left, ret);
            ret.Add(root.val);
            Traverse(root.right, ret);
        }


        static void Main(string[] args)
        {
            var test = PlusOne( new []{9});
            Console.ReadKey();
        }
    }
}