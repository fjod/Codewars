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
        
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            Traverse(root, "", paths);
            return paths;
        }

        private static void Traverse(TreeNode root, string current, List<string> paths)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                if (current != "")
                    paths.Add($"{current}->{root.val}");
                else 
                    paths.Add($"{root.val}");
                return;
            }

            if (current == "")
            {
                current = root.val.ToString();
            }
            else
            {
                current = $"{current}->{root.val.ToString()}";    
            }
            
            Traverse(root.left, current, paths);
            Traverse(root.right, current, paths);
        }


        static void Main(string[] args)
        {
            TreeNode five = new TreeNode {val = 5};
            TreeNode two = new TreeNode {val = 2, right = five};
            TreeNode three = new TreeNode {val = 3};
            TreeNode one = new TreeNode {val = 1, left = two, right = three};
            var test = BinaryTreePaths(one);
            Console.ReadKey();
        }
    }
}