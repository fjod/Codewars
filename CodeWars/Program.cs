using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        
        public static int UniquePaths(int m, int n) // 3 7
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }
            for (int i = 0; i < m; i++)
            {
                dp[i][0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0][i] = 1;
            }

            dp[0][0] = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    dp[j][i] = dp[j - 1][i] + dp[j][i-1];
                }
            }

            return dp[m - 1][n - 1];
        }
    
        static void Main(string[] args)
        {
            UniquePaths(3, 7);
            Console.ReadKey();
        }
    }
}