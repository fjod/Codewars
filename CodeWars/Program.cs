using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Threading;

namespace CodeWars
{
    class Program
    {
        public static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue, maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice) minPrice = prices[i]; // if min is updated, we cant sell it anyway
                else
                    maxProfit = Math.Max(maxProfit, prices[i] - minPrice); //if min is not updated, check if it's max
            }
            return maxProfit;
        }


        static void Main(string[] args)
        {
            var q = MaxProfit(new[] {2,4,1});
            Console.ReadKey();
        }
    }
}