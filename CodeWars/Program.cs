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

            public int MinOperations(int[] nums)
            {
                if (nums.Length == 0) return 0;
                int count = 0;
                while (true)
                {
                    if (nums.All(i => i == 0)) return count;
                    var min = nums.Where(i => i != 0).Min();
                    
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] -= min;
                        if (nums[i] < 0) nums[i] = 0;
                    }

                    count++;
                }
            }

            static void Main(string[] args)
            {
                // var q = MaxProfit(new []{7,1,5,3,6,4});
                var q = CountVowelStrings(32);
            }
        }
    }
}