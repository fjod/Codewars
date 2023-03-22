using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        private Dictionary<(int, int), bool> visited = new Dictionary<(int, int), bool>();
        private int current;
        private int max;
        private int maxLen;
        private int maxWidth;
        public int MaxAreaOfIsland(int[][] grid)
        {
            maxLen = grid.Length;
            maxWidth = grid.First().Length;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (visited.ContainsKey((i,j))) continue;
                    dfs(i, j, grid);
                    max = Math.Max(current, max);
                    current = 0;
                }
            }

            return max;
        }

        private void dfs(int i, int j, int[][] grid)
        {
            if (i < 0 || i >= maxLen) return;
            if (j < 0 || j >= maxWidth) return;
            if (grid[i][j] == 1 && !visited.ContainsKey((i,j)))
            {
                visited.Add((i,j), true);
                current += 1;
                dfs(i +1 , j, grid);
                dfs(i -1 , j, grid);
                dfs(i  , j +1, grid);
                dfs(i  , j - 1, grid);
            }
        }

        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }


}