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
        public static bool CanJump(int[] nums)
        {
            if (nums.Length == 1)
                return (nums.First() == 0 || nums.First() == 1);
            return JumpInner3(nums);
        }
        
        public static bool CanJump2(int[] nums) {
            int goal = nums.Length - 1;
            for (int i = nums.Length-1; i>=0; i--)
            {
                if (nums[i] + i >= goal) //можно ли с этой позиции прыгнуть до или дальше цели?
                {
                    goal = i; //если можно, то смещаем цель ближе к началу массива
                }
            }

            return goal == 0  ;
        }

        //Time Limit Exceeded
        private static Dictionary<int, bool> mem = new Dictionary<int, bool>(); 
        private static bool JumpInner(int[] nums)
        {
            if (nums.Length == 0) return false;
            if (mem.ContainsKey(nums.Length)) return false;
            for (int i = nums[0]; i > 0; i--)
            {
                if (i >= nums.Length - 1) return true;
                var skippedArr = nums.Skip(i).ToArray();
                if (JumpInner(skippedArr)) return true;
            }
            mem.Add(nums.Length, false);
            return false;
        }

        // не работает с [2,0,0]
        private static bool JumpInner3(int[] nums)
        {
            if (nums.Length == 2)
            {
                if (nums.First() >= 1) return true;
                return false;
            }

            var secondBeforeLast = nums[^2];
            if (secondBeforeLast >= 1) return JumpInner3(nums.Take(nums.Length - 1).ToArray());
            return false;
        }
        
        static void Main(string[] args)
        {
            var q = CanJump(new[] {2, 3, 1, 1, 4});

            Console.ReadKey();
        }
    }
}