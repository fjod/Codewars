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
        public static string LongestPalindrome(string s)
        {
            int high = 0;
            int low = 0;
            
            for (int i = 0; i < s.Length; i++)
            {
                int current = Math.Max(TestPalindrome(s, i, i), TestPalindrome(s, i, i + 1));
                if (current > high - low)
                {
                    high = i + current / 2;
                    low = i - (current-1) / 2;
                }
            }

            return s.Substring(low, high -low  + 1);
        }

        static int  TestPalindrome(string s,  int low, int high)
        {
            while (low >=0 && high< s.Length && s[high] == s[low])
            {
                high++;
                low--;
            }

            return high - low - 1;
        }
     


        static void Main(string[] args)
        {
            var test = LongestPalindrome("babad");
            Console.ReadKey();
        }
    }


}