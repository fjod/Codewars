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
            public int ArrayPairSum(int[] nums)
            {
                List<(int, int)> arr = new List<(int, int)>(nums.Length / 2);
                List<int> temp = new List<int>(2);
                foreach (var current in nums.OrderBy(n => n))
                {
                    temp.Add(current);
                    if (temp.Count == 2)
                    {
                        arr.Add((temp[0], temp[1]));
                        temp.Clear();
                    }
                }

                return arr.Select(tuple => tuple.Item1).Sum();
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = MaxScore("0100");
            }
        }
    }
}