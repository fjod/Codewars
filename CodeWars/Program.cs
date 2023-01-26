using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        // top-down (start from goal and recurse down to basecases)
        public static int Rob(int[] nums)
        {
            Dictionary<int, int> robVals = new Dictionary<int, int>();
            robVals[0] = nums[0];
            robVals[1] = Math.Max(nums[0], nums[1]);

            calcRob(nums.Length - 1, robVals, nums);
            return robVals[nums.Length - 1];
        }

        private static int calcRob(int house, Dictionary<int, int> robVals, int[] nums)
        {
            if (robVals.ContainsKey(house))
                return robVals[house];
            var robPrev = calcRob(house - 1, robVals, nums);
            var robPrevPrevAndCurrent = calcRob(house - 2, robVals, nums) + nums[house];
            robVals[house] = Math.Max(robPrev, robPrevPrevAndCurrent);
            return robVals[house];
        }

        // bottom-up (start from basecases and go upper towards goal)
        public static int Rob2(int[] nums)
        {
            var robVals = new int[nums.Length];
            robVals[0] = nums[0];
            robVals[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                var robPrev = robVals[i - 1];
                var robPrevPrevAndCurrent = robVals[i-2] + nums[i];
                robVals[i] = Math.Max(robPrev, robPrevPrevAndCurrent);
            }

            return robVals.Max();
        }

        static void Main(string[] args)
        {
            var test = Rob(new[] {1, 2, 3, 1});
            test = Rob2(new[] {1, 2, 3, 1});
            Console.ReadKey();
        }
    }
}