using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool IsValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<int>> rows = new Dictionary<int, HashSet<int>>(9);
            Dictionary<int, HashSet<int>> cols = new Dictionary<int, HashSet<int>>(9);
            Dictionary<(int, int), HashSet<int>> squares = new Dictionary<(int, int), HashSet<int>>(9);
            for (int row = 0; row < board.Length; row++)
            {
                rows.Add(row, new HashSet<int>());
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (!cols.ContainsKey(col)) cols.Add(col, new HashSet<int>());
                    if (!squares.ContainsKey((row/3,col/3))) squares.Add((row/3,col/3), new HashSet<int>());

                    var currentChar = board[row][col];
                    if (currentChar == '.') continue;
                    var rowStatus = rows[row].Add(currentChar);
                    var colStatus = cols[col].Add(currentChar);
                    var squareStatus = squares[(row / 3, col / 3)].Add(currentChar);
                    if (rowStatus == false || colStatus == false || squareStatus == false) return false;
                }
            }

            return true;
        }


        static void Main(string[] args)
        {
            var test = ProductExceptSelf(new[] {1,2, 3, 4});
            Console.ReadKey();
        }
    }
}