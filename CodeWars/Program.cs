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
        //67 / 113 testcases passed for my solution
        private static int maxLen;
        private static int maxWidth;
        private static List<IList<int>> ret = new List<IList<int>>();
        public static IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            maxLen = heights.Length;
            maxWidth = heights.First().Length;
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    visitedPacific.Clear();
                    visitedAtlantic.Clear();
                    var pacific = CanGoPacific(i, j, heights, int.MaxValue);
                    var atlantic = CanGoAtlantic(i, j, heights, int.MaxValue);
                    var newList = new List<int>(2) {i, j};
                    if (pacific && atlantic && !ret.Any(l => l.SequenceEqual(newList)))
                    {
                        ret.Add(newList);
                    }
                }
            }

            return ret;
        }

        private static Dictionary<(int, int), bool> visitedPacific = new Dictionary<(int, int), bool>(); 
        static bool CanGoPacific(int i, int j, int[][] grid, int prevCellValue)
        {
            if (visitedPacific.ContainsKey((i, j))) return false;
            visitedPacific.Add((i,j), true);
            if (i < 0 || i >= maxLen) return false;
            if (j < 0 || j >= maxWidth) return false;
            var current = grid[i][j];
            if (i == 0 && current <= prevCellValue) return true;
            if (j == 0 && current <= prevCellValue) return true;
            
            if (current > prevCellValue) return false;
            var goUp = CanGoPacific(i - 1, j, grid, current);
            var goLeft =   CanGoPacific(i , j - 1, grid, current);
            var goRight =   CanGoPacific(i , j + 1, grid, current);
            return goUp || goLeft || goRight;
        }

        private static Dictionary<(int, int), bool> visitedAtlantic = new Dictionary<(int, int), bool>();
        static bool CanGoAtlantic(int i, int j, int[][] grid, int prevCellValue)
        {
            if (visitedAtlantic.ContainsKey((i, j))) return false;
            visitedAtlantic.Add((i,j), true);
            if (i < 0 || i >= maxLen) return false;
            if (j < 0 || j >= maxWidth) return false;
            var current = grid[i][j];
            if (i == maxLen - 1 && current <= prevCellValue) return true;
            if (j == maxWidth - 1 && current <= prevCellValue) return true;
          
            if (current > prevCellValue) return false;
            var goUp = CanGoAtlantic(i+ 1, j, grid, current);
            var goLeft = CanGoAtlantic(i , j + 1, grid, current);
            var goRight = CanGoAtlantic(i , j - 1, grid, current);
            return goUp || goLeft || goRight;
        }
        
        static void Main(string[] args)
        {
            var q = PacificAtlantic(new[]
            {
                new []{1,2,2,3,5},
                new []{3,2,3,4,4},
                new []{2,4,5,3,1},
                new []{6,7,1,4,5},
                new []{5,1,1,2,4}
            });
            
            var q1 = PacificAtlantic(new[]
            {
                new []{1,2,3},
                new []{8,9,4},
                new []{7,6,5},
            });
            Console.ReadKey();
        }
    }


}