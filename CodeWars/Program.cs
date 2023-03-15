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
            
        public static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            InnerPermute(ret, nums, 0);
            return ret;
        }


        static void InnerPermute(IList<IList<int>> ret, int[] nums, int level)
        {
            if (level == nums.Length)ret.Add(new List<int>(nums));
            else
            {
                for (int i = level; i < nums.Length; i++)
                {
                    (nums[i], nums[level]) = (nums[level], nums[i]);
                    InnerPermute(ret, nums, level + 1);
                    (nums[i], nums[level]) = (nums[level], nums[i]);
                }
            }
        }
        
        static void Main(string[] args)
        {
            var q = Permute(new[] {1,2,3});
            Console.ReadKey();
        }
    }
}