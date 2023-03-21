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
        public static int NumIslands(char[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var visited = new bool[m, n];
            var numIslands = 0;


            void dfs(int i, int j, char[][] grid)
            {
                if (i < 0 || i >= m) return;
                if (j < 0 || j >= n) return;
                if (visited[i, j] == true || grid[i][j] == '0') return;

                visited[i, j] = true;

                dfs(i + 1, j, grid);
                dfs(i - 1, j, grid);
                dfs(i, j - 1, grid);
                dfs(i, j + 1, grid);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (visited[i, j] == false && grid[i][j] == '1')
                    {
                        numIslands++;
                        dfs(i, j, grid);
                    }
                }
            }

            return numIslands;
        }

        // almost solved by myself
        static void Main(string[] args)
        {
            var q = NumIslands(new[]
            {
                new[] {'1', '1', '1'},
                new[] {'0', '1', '0'},
                new[] {'1', '1', '1'}
            });

            Console.ReadKey();
        }
    }
}