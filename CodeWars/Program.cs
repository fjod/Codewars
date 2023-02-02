using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        
        public void SetZeroes(int[][] matrix)
        {
            List<(int, int)> zeroesLocation = new List<(int, int)>();
            for (var i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0) zeroesLocation.Add((i,j));
                }
            }
            
            for (var i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (zeroesLocation.Any(tuple =>
                        {
                            var (row, col) = tuple;
                            return row == i || col == j;
                        }))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
          
            Console.ReadKey();
        }
    }
}