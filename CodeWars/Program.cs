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
        public static bool DivideArray(int[] nums)
        {
            bool[] used = new bool[nums.Length];
            Array.Fill(used, false);
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i] != true)
                {
                    var current = nums[i];
                    if (!FindSameNumber(nums, used, current, i + 1)) return false;
                    used[i] = true;
                }
            }

            return true;
        }

        static bool  FindSameNumber(int[] nums, bool[] used, int target, int start)
        {
            for (int i = start; i < nums.Length; i++)
            {
                if (nums[i] == target && used[i] == false)
                {
                    used[i] = true;
                    return true;
                }
            }

            return false;
        }


        static void Main(string[] args)
        {
            var test = DivideArray( new []{3,2,3,2,2,2});
            Console.ReadKey();
        }
    }
}