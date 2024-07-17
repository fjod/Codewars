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
        static IEnumerable<int> Data()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
        static void Main(string[] args)
        {
            try
            {
                var res = Data();
                res = res.Where(x => x % 2 == 0&& res.Any(t => t == x - 1));
                Console.Write(res.Count());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
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