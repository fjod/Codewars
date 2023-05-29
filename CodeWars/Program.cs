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
            public static int SmallestEqual(int[] nums) {

                for (int i = 0; i < nums.Length; i++)
                {
                    var mod = i % 10;
                    if (mod == nums[i]) return i;
                }

                return -1;
            }

            static void Main(string[] args)
            {
                var arr = SmallestEqual(new[] {0, 1, 2});
            }
        }
    }
}