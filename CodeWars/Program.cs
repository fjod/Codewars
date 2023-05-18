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
            public int RepeatedNTimes(int[] nums)
            {
                return nums.GroupBy(n => n).First(g => g.Count() ==nums.Length/2).First();
            }

          

            static void Main(string[] args)
            {
                // var q = MaxProfit(new []{7,1,5,3,6,4});
                var q = CountVowelStrings(32);
            }
        }
    }
}