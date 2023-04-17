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
        public static IList<string> LetterCombinations(string digits)
        {
            if (digits == string.Empty) return new List<string>();
            List<string> chars = new List<string>
            {
                String.Empty,
                String.Empty,
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };
            if (digits.Length == 1)
            {
                var dig = int.Parse(digits[0].ToString());
                return chars[dig].Select(c => c.ToString()).ToList();
            }
        
            var results = new List<string>() { "" };
            foreach (var digit in digits)
            {
                var keys = chars[digit - '0'];
                if (keys.Length == 0) continue;

                var temp = new List<string>();
                foreach (var result in results)
                foreach (var ch in keys)
                    temp.Add(result + ch.ToString());

                results = temp;
            }

            if (results.Count == 1 && results[0] == "") results.Clear();
            return results;
        }


        static void Main(string[] args)
        {
            var q = LetterCombinations("23");
        }
    }
}