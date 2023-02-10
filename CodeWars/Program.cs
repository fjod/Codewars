using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        
        public static int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;

            foreach (var coin in coins)
                for (int x = coin; x <= amount; x++)
                    dp[x] += dp[x - coin];

            return dp[amount];
        }

        static void Main(string[] args)
        {
            Change(5, new[] {1, 2, 5});
            Console.ReadKey();
        }
    }
}