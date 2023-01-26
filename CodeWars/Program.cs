using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 1) return cost[0];
            if (cost.Length == 2) return Math.Min(cost[0], cost[1]);
            int[] costs = new int[cost.Length + 1];
            costs[0] = cost[0];
            costs[1] = cost[1];
            for (int i = 2; i < cost.Length; i++)
            {
                costs[i] = cost[i] + Math.Min(costs[i - 1], costs[i - 2]);
            }
            return Math.Min(costs[cost.Length-1], costs[cost.Length-2]);

        }

        static void Main(string[] args)
        {
            var q = MinCostClimbingStairs(new[] {10, 15, 20});
            Console.ReadKey();
        }
    }
}