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
            public int MaxCount(int m, int n, int[][] ops)
            {
                if (ops.Length == 0)
                {
                    return m * n;
                }

                var minX = ops.Select(x => x[0]).Min();
                var minY = ops.Select(x => x[1]).Min();
                return minX * minY;
            }

            static void Main(string[] args)
            {
                var arr = LuckyNumbers(new[] {new[] {1, 10, 4, 2}, new[] {9, 3, 8, 7}, new[] {15, 16, 17, 12}});
            }
        }
    }
}