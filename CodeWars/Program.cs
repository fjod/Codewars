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
        // easy dp ftw
        public static int MinPathSum(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[0].Length];
            }
            dp[0][0] = grid[0][0];
            for (int i = 1; i < grid[0].Length; i++)
            {
                dp[0][i] = dp[0][i - 1] + grid[0][i];
            }
            for (int i = 1; i < grid.Length; i++)
            {
                dp[i][0] = dp[i - 1][0] + grid[i][0];
            }

            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {
                    dp[i][j] = grid[i][j] + Math.Min(dp[i-1][j], dp[i][j-1]);
                }
            }

            return dp[^1][^1];
        }

        // bruteForce 25 / 61 testcases passed
        static int Traverse(int[][] grid, int x, int y)
        {
            if (x == grid.Length - 1 && y == grid[0].Length - 1) return grid[x][y];
            if (x >= grid.Length) return int.MaxValue;
            if (y >= grid[0].Length) return int.MaxValue;
            return grid[x][y] + Math.Min(Traverse(grid, x+1, y), Traverse(grid, x, y+1));
        }

        static void Main(string[] args)
        {
            var test = MinPathSum(new[] {new[] {1, 3, 1}, new[] {1, 5, 1}, new []{4,2,1}});
        }
    }
}