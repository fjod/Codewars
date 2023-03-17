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
        public static int MaxSubArray(int[] nums)
        {
            int curSum = 0;
            int maxSub = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                // если сумма оказалась отрицательной, то сбрасываем начало подсчета
                if (curSum < 0) curSum = 0;
                curSum += nums[i];
                maxSub = Math.Max(curSum, maxSub);
            }

            return maxSub;
        }

        static void Main(string[] args)
        {
            var q = MaxSubArray(new[] {-2,1,-3,4,-1,2,1,-5,4});
            Console.ReadKey();
        }
    }
}