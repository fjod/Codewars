using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        private static List<IList<int>> ret = new List<IList<int>>();
        private static List<int> subset = new List<int>();
        public static IList<IList<int>> Subsets(int[] nums)
        {
            BackTrack(nums, 0);
            return ret;
        }

        private static void BackTrack(int[] nums, int level)
        {
            if (level >= nums.Length)
            {
                ret.Add(new List<int>(subset));
                return;
            }
            
            subset.Add(nums[level]);
            BackTrack(nums, level +1);
            subset.Remove(nums[level]);
            BackTrack(nums, level +1);
        }


        static void Main(string[] args)
        {
            var q = Subsets(new[] {1, 2, 3});
            Console.ReadKey();
        }
    }
}