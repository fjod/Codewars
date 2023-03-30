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
        public int MaxProduct(int[] nums)
        {
            int max = nums.Max();
            int currentMax = 1;
            int currentMin = 1;
            foreach (var n in nums)
            {
                var tmp = currentMax * n;
                if (n == 0)
                {
                    currentMax = 1;
                    currentMin = 1;
                    continue;
                }
                currentMax = new int[]{n, n * currentMax, n*currentMin}.Max();
                currentMin = new int[]{n, n * currentMin, tmp}.Min();
                max = Math.Max(max, currentMax);
            }

            return max;
        }


        static void Main(string[] args)
        {
            var test = NumDecodings("206");
            Console.ReadKey();
        }
    }
}