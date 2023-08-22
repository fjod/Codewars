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
            var a = SumOfSquares(new[] {2,7,1,19,18,3});
            Console.Write(1);
        }
        
        static public int SumOfSquares(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums.Length % (i + 1) == 0)
                {
                    sum += nums[i] * nums[i];
                }
            }

            return sum;
        }
    }
}