using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        //T:O(M*N)
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;
            var dp = new bool[s1.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[s2.Length + 1];
            }

            dp[s1.Length][s2.Length] = true;
            for (int i = s1.Length; i >= 0; i--)
            {
                for (int j = s2.Length; j >= 0; j--)
                {
                    if (i < s1.Length)
                    {
                        if (s1[i] == s3[i + j] && dp[i + 1][j])
                        {
                            dp[i][ j] = true;
                        }
                    }
                    if (j < s2.Length)
                    {
                        if (s2[j] == s3[i + j] && dp[i][j+1])
                        {
                            dp[i][j] = true;
                        }
                    }
                }
            }

            return dp[0][0];
        }

        static void Main(string[] args)
        {
            var test = IsInterleave("aabcc", "dbbca", "aadbbcbcac");
        }
    }
}