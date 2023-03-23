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
        public static int OrangesRotting(int[][] grid)
        {
            int minutes = 0;
            bool allAreRotten = true;
            while (allAreRotten)
            {
                rottenOnThisTurn.Clear();
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        rot(i, j, grid);
                    }
                }

                var gotFresh = grid.SelectMany(g => g).Any(i => i == 1);
                allAreRotten = gotFresh;
                if (rottenOnThisTurn.Count == 0 && gotFresh) return -1;
                if (rottenOnThisTurn.Count > 0 ) minutes++;
            }

            return minutes;
        }

        private static Dictionary<(int, int), bool> rottenOnThisTurn = new Dictionary<(int, int), bool>();
        private static void rot(int i, int j, int[][] grid)
        {
            if (i < 0 || j < 0 || i == grid.Length || j == grid[0].Length) return;
            if (grid[i][j] != 2) return;
            if (rottenOnThisTurn.ContainsKey((i, j))) return;
            if (needToRotIt(i + 1, j, grid)) rotThisOne(i + 1, j, grid);
            if (needToRotIt(i, j + 1, grid)) rotThisOne(i , j+1, grid);
            if (needToRotIt(i - 1, j, grid))rotThisOne(i - 1, j, grid);
            if (needToRotIt(i , j-1, grid)) rotThisOne(i , j-1, grid);
        }

        private static bool needToRotIt(int i, int j, int[][] grid)
        {
            if (i < 0 || j < 0 || i == grid.Length || j == grid[0].Length) return false;
            if (grid[i][j] == 1) return true;
            return false;
        }
        
        private static void rotThisOne(int i, int j, int[][] grid)
        {
            if (i < 0 || j < 0 || i == grid.Length || j == grid[0].Length) return;
            if (rottenOnThisTurn.ContainsKey((i, j))) return;
            
            if (grid[i][j] ==1)
            {
                grid[i][j] = 2;
                rottenOnThisTurn.Add((i,j), true);
            }
        }

        static void Main(string[] args)
        {
            var q1 = OrangesRotting(new[]
            {
                new []{2,1,1},
                new []{1,1,0},
                new []{0,1,1},
            });

            Console.ReadKey();
        }
    }


}