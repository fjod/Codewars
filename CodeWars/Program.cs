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
        
        public int LengthOfLastWord(string s)
        {

            return s.Split(" ").Last(s => !string.IsNullOrEmpty(s)).Length;
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