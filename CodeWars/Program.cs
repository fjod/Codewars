using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        // almost made it by myself
        public static int LengthOfLongestSubstring(string s)
        {
            int leftPointer = 0, rightPointer = 0, maxLength = 0;
            HashSet<int> chars = new HashSet<int>();

            while (rightPointer < s.Length) {
                char currChar = s[rightPointer];
                if (chars.Contains(currChar)) { // Move left pointer until all duplicate chars removed
                    chars.Remove(s[leftPointer]);
                    leftPointer++;
                } else {
                    chars.Add(currChar);
                    maxLength = Math.Max(maxLength, rightPointer - leftPointer + 1);
                    rightPointer++;
                }
            }
            return maxLength;
        }


        static void Main(string[] args)
        {
            var q = LengthOfLongestSubstring("dvdf");
            Console.ReadKey();
        }
    }
}