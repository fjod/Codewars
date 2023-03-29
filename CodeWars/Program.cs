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
        public static int NumDecodings(string s)
        {

            var dp = Enumerable.Repeat(1, s.Length + 1).ToArray();
            for (int i = s.Length -1; i >= 0; i--)
            {
                var current = s[i];
                if (current == '0') dp[i] = 0;
                else dp[i] = dp[i + 1];

                if (i != s.Length - 1 &&
                    (current == '1' || 
                     (current == '2' && "0123456".Contains(s[i + 1]))
                    ))
                    dp[i] += dp[i + 2];
            }

            return dp[0];

        }


        static void Main(string[] args)
        {
            var test = NumDecodings("206");
            Console.ReadKey();
        }
    }
}