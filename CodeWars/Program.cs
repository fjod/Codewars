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

        public int MinimumTotal(IList<IList<int>> triangle) {
        
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
                }
            }

            return triangle[0][0];
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