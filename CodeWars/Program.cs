
using System;

namespace CodeWars
{
    class Program
    {

        
        public static bool IsPalindrome(string s)
        {
            var converted = s.ToLower().Replace(" ", string.Empty).Trim();
            converted = System.Text.RegularExpressions.Regex.Replace(converted, "[^a-zA-Z0-9]+", "", System.Text.RegularExpressions.RegexOptions.Compiled);
            if (converted.Length == 1) return true;
            var p1 = 0;
            var p2 = converted.Length - 1;
            while (p1 <= p2)
            {
                if (converted[p1] != converted[p2]) return false;
                p1++;
                p2--;
            }

            return true;
        }

        static void Main(string[] args)
        {
            var q = IsPalindrome("a.");
            Console.ReadKey();
        }
    }
}