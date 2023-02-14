using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace CodeWars
{
    class Program
    {
        
        public static int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var left = target - nums[i];
                if (dict.ContainsKey(left))
                {
                    return new[] {i, dict[left]};
                }
                if (!dict.ContainsKey(nums[i])) dict.Add(nums[i], i);
            }

            throw new ArgumentException("");
        }
        
     

        static void Main(string[] args)
        {
            var test = TwoSum(new []{2,7,11,15}, 9);
            Console.ReadKey();
        }
    }
}