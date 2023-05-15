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
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        public class Solution
        {
            public static IList<TreeNode> AllPossibleFBT(int n)
            {
                Dictionary<int, List<TreeNode>> ret = new Dictionary<int, List<TreeNode>>(n + 1);
                ret.Add(0, new List<TreeNode>());
                ret.Add(1, new List<TreeNode> {new TreeNode(0)});

                for (int i = 2; i <= n; i++)
                {
                    ret.Add(i, new List<TreeNode>());

                    for (int left = 1; left < i; left++)
                    {
                        int right = i - left - 1;
                        var forwardTree = ret[left];
                        var backwardTree = ret[right];
                        if (forwardTree.Any() && backwardTree.Any())
                        {
                            foreach (var lTree in forwardTree)
                            {
                                foreach (var rTree in backwardTree)
                                {
                                    ret[i].Add(new TreeNode(0, lTree, rTree));
                                }
                            }
                        }
                    }
                }

                return ret[n];
            }

            static void Main(string[] args)
            {
                // var q = MaxProfit(new []{7,1,5,3,6,4});
                var q = AllPossibleFBT(7);
            }
        }
    }
}