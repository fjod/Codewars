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
        static void Main(string[] args)
        {
            Console.Write(1);
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null) return false;
            if (q == null) return false;
            if (p.val != q.val) return false;
            var left = IsSameTree(p.left, q.left);
            if (!left) return false;
            var right = IsSameTree(p.right, q.right);
            return right;
        }
    }
}