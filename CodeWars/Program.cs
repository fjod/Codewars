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
        static string RemoveSpecialChars(string w)
        {
            const string chars = "!?',;.";
            sb.Clear();
            foreach (var c in w.Where(c => !chars.Contains(c)))
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        private static StringBuilder sb = new StringBuilder();
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            var splitted = paragraph
                .Replace(',', ' ')
                .Split(' ')
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower())
                .Select(RemoveSpecialChars)
                .GroupBy(w => w)
                .OrderByDescending(kvp => kvp.Count());
            foreach (var grouping in splitted)
            {
                var word = grouping.Key;
                if (!banned.Contains(word))
                    return word;
            }

            throw new Exception("It is guaranteed there is at least one word that is not banned, and that the answer is unique");
        }


        static void Main(string[] args)
        {
            var test = MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] {"hit"});
            Console.ReadKey();
        }
    }
}