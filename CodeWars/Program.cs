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
        // I mistook greedy for dp
        public static bool CanJump(int[] nums)
        {
            int maxRight = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxRight) { return false; } // we cant get to this pos
                if (i + nums[i] > maxRight) // can we jump more then previously?
                    maxRight = i + nums[i]; // if we can, save this position
                if (maxRight >= nums.Length - 1) // if we arrived to the end then return
                    return true;
            }

            return false;
        }
        
        public static bool CanJump2(int[] nums) {
            if (nums.Length == 1)
                return (nums.First() == 0 || nums.First() == 1);
            return JumpInner2(nums);
        }
  
        // prev code 136 / 171 testcases passed 
        private  bool JumpInner(int[] nums)
        {
            if (nums.Length == 2)
            {
                if (nums.First() >= 1) return true;
                return false;
            }

            var secondBeforeLast = nums[^2];
            if (secondBeforeLast >= 1) return JumpInner(nums.Take(nums.Length - 1).ToArray());
            return false;
        }

        // 73 / 171 testcases passed
        private static HashSet<int> memo = new HashSet<int>();
        private static bool JumpInner2(int[] nums)
        {
            if (memo.Contains(nums.GetHashCode())) return false;
            if (nums.Length == 2)
            {
                if (nums.First() >= 1) return true;
                memo.Add(nums.GetHashCode());
                return false;
            }
            if (nums.Length == 1) return true;
            var first = nums[0];
            if (first == 0)
            {
                memo.Add(nums.GetHashCode());
                return false;

            };
            for (int i = 1; i <= first; i++)
            {
                if (JumpInner2(nums.Skip(i).ToArray())) return true;
            }

            memo.Add(nums.GetHashCode());
            return false;
        }

        static void Main(string[] args)
        {
            var q = CanJump(new []{3,2,1,0,4});
        }
    }
}