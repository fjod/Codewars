using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace CodeWars
{
    class Program
    {
        public static int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            if (matrix.Length == 1) return matrix[0].Any(m => m == '1') ? 1 : 0;
            var maxRow = matrix.Length;
            var maxCol = matrix[0].Length;
            var max = Math.Max(maxRow, maxCol);
            int[][] dp = new int[max][];
            for (int i = 0; i < max; i++)
            {
                dp[i] = new int[max];
            }

            var ret = 0;
            for (int i =0; i < maxRow; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    if((i==0 || j==0) && matrix[i][j] == '1'){
                        dp[i][j] = 1;
                    }
                    
                    if (i > 0 && j > 0 && matrix[i - 1][ j - 1] == '1')
                    {
                        var up = dp[i - 1][j];
                        var left = (dp[i][j-1]);
                        var diag = (dp[i-1][j-1]);
                        var min =Math.Min(Math.Min(up, left), diag)+1;
                        dp[i][j] = min;
                        if (dp[i][j] > ret) ret = dp[i][j];
                    }
                }   
            }

            if (ret == 0)
                if (matrix.SelectMany(m => m).Any(m => m == '1'))
                    return 1;
            return ret * ret;
        }

        static int  toInt(char c)
        {
            return c == '1' ? 1 : 0;
        }
        
        static void Main(string[] args)
        {
            char[][] input = new char[5][];
            input[0] = new char[] {'1', '1', '1', '1', '1'};
            input[1] = new char[] {'1', '1', '1', '1', '1'};
            input[2] = new char[] {'0', '0', '0', '0', '0'};
            input[3] = new char[] {'1', '1', '1', '1', '1'};
            input[4] = new char[] {'1', '1', '1', '1', '1'};
            
            char[][] input2 = new char[2][];
            input2[0] = new char[] {'1', '1'};
            input2[1] = new char[] {'1', '1'};
         

            var ret = MaximalSquare(input);
            Console.ReadKey();
        }
    }
}