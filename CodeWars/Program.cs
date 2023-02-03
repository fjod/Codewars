using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length) return false;
            int pos = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (CheckStrings(s, goal, pos)) return true;
                pos++;
            }

            return false;
        }

        private static bool CheckStrings(string s, string goal, int pos)
        {
            int shift = 0;
            for (int i = 0; i < s.Length; i++)
            {
                shift = pos + i;
                if (shift >= goal.Length) shift = (pos + i) -goal.Length;
                if (s[i] != goal[shift]) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            var q = RotateString("abcde", "cdeab");
            Console.ReadKey();
        }
    }
}