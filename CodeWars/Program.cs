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
        public static int CountSubstrings(string s)
        {

            int ret = 0;
            StringBuilder sbOuter = new StringBuilder();
            StringBuilder sbInner = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sbOuter.Clear();
                var current = s[i];
                sbOuter.Append(current);
                if (IsPalindrome(sbOuter)) ret += 1;
                sbInner.Clear();
                sbInner.Append(sbOuter.ToString());
                for (int j = i+1; j < s.Length; j++)
                {
                    var next = s[j];
                    sbInner.Append(next);
                    if (IsPalindrome(sbInner)) ret += 1;
                }
            }

            return ret;
        }

        private static bool IsPalindrome(StringBuilder sbInner)
        {
            if (sbInner.Length == 1) return true;
            var left = 0;
            var right = sbInner.Length - 1;
            while (left <= right)
            {
                if (sbInner[left] != sbInner[right]) return false;
                left++;
                right--;
            }

            return true;
        }


        static void Main(string[] args)
        {
            var test = CountSubstrings("aaa");
            Console.ReadKey();
        }
    }


}