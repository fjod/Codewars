using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeWars
{
    class Program
    {
        public static int DeleteAndEarn(int[] nums)
        {
            var groups = nums.GroupBy(g => g).ToList();
            int[] initial = new int[10001];
            int count = 0;
            foreach (var grouping in groups)
            {
                initial[grouping.Key] = grouping.Sum();
                count++;
            }
            // (0,1,2,3,4,5,6....10000)
            // (0,0,4,9,4,0,0,0...0)
            int[] dpVals = new int[10001];
            dpVals[0] = initial[0];
            dpVals[1] = initial[1];
            for (int i = 2; i < initial.Length; i++)
            {
                dpVals[i] = Math.Max(dpVals[i - 2] + initial[i], dpVals[i - 1]);
            }

            return dpVals.Last();
        }

        static void Main(string[] args)
        {
            var q = DeleteAndEarn(new []{2,2,3,3,3,4});
            Console.ReadKey();
        }
    }
}