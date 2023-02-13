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
        
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!set.Add(nums[i]))
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool ContainsDuplicate2(int[] nums) {
            HashSet<int> set = new HashSet<int>();
        
            foreach (int x in nums){
                if (set.Contains(x)) return true;
                set.Add(x);
            }
            return false;
        }

        static void Main(string[] args)
        {
            ContainsDuplicate( new[] {1, 2, 5, 1});
            ContainsDuplicate2( new[] {1, 2, 5, 1});
            Console.ReadKey();
        }
    }
}