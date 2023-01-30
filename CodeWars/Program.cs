using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace CodeWars
{
    class Program
    {
        private static int[][] dp;
        private static string t1, t2;
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            t1 = text1;
            t2 = text2;
            dp = new int[text1.Length][];
            for (int i = 0; i < text1.Length; i++)
            {
                dp[i] = new int[text2.Length];
            }

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }


            return dpSolve(0, 0);
        }

        private static int dpSolve(int p1, int p2)
        {
            if (p1 == t1.Length) return 0;
            if (p2 == t2.Length) return 0;
            if (dp[p1][p2] != -1) {
                return dp[p1][p2];
            }

            // Option 1: we don't include text1[p1] in the solution.
            int option1 = dpSolve(p1 + 1, p2);
            
            // Option 2: We include text1[p1] in the solution, as long as
            // a match for it in text2 at or after p2 exists.
            int firstOccurence = t2.IndexOf(t1[p1], p2);
            int option2 = 0;
            if (firstOccurence != -1) {
                option2 = 1 + dpSolve(p1 + 1, firstOccurence + 1);
            }

            dp[p1][p2] = Math.Max(option1, option2);

            return dp[p1][p2];
        }

        static void Main(string[] args)
        {
            var ret = LongestCommonSubsequence("abc", "abc");
            Console.ReadKey();
        }
    }
}