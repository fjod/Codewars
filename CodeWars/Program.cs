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
        public static string OddString(string[] words)
        {
            List<(int, string)> diffs = new List<(int, string)>();
            for (int i = 0; i < words.Length; i++)
            {
                var current = CalcDiff(words[i]);
                diffs.Add((current, words[i]));
            }

            var group = diffs.GroupBy(c => c.Item1).OrderByDescending(c => c.Count()).Last();
            return group.First().Item2;
        }

        private static StringBuilder sb = new StringBuilder();
        static int CalcDiff(string w)
        {
            sb.Clear();
            for (int i = 1; i < w.Length; i++)
            {
                sb.Append(w[i] - w[i - 1]);
                sb.Append('g');
            }

            return sb.ToString().GetHashCode();
        }

       


        static void Main(string[] args)
        {
            var test = OddString( new []{"abm","bcn","alm"});
            Console.ReadKey();
        }
    }
}