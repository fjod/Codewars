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

        public int SumNumbers(TreeNode root)
        {

            List<int> sums = new List<int>();
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null) return root.val;

            Sum(root.val, root.left, sums);
            Sum(root.val, root.right, sums);
            return sums.Sum();
        }

        private void Sum(int rootVal, TreeNode node, List<int> sums)
        {
            if (node == null) return;
            if (node.left == null && node.right == null)
            {
                sums.Add(rootVal*10 + node.val);
                return;
            }
            Sum(rootVal*10 +  node.val, node.left, sums);
            Sum(rootVal*10 +  node.val, node.right, sums);
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = MaxProfit(new[] {1, 2, 3, 4, 5});
        }
    }
}