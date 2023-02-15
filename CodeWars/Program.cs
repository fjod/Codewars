using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<(string, int[])> dict = new List<(string, int[])>();
            for (int i = 0; i < strs.Length; i++)
            {
                dict.Add((strs[i], CreateArray(strs[i])));
            }

            var test = dict.GroupBy(g => CreateHashCode(g.Item2)).ToList();
            IList<IList<string>> ret = new List<IList<string>>();
            foreach (var v in test)
            {
                ret.Add(new List<string>(v.Select(z => z.Item1)));
            }

            return ret;
        }

        private static StringBuilder sb = new StringBuilder();
        private static int CreateHashCode(int[] i)
        {
            sb.Clear();
            for (int j = 0; j < i.Length; j++)
            {
                if (i[j] != 0)
                {
                    sb.Append(j);
                    sb.Append(i[j]*17);
                }
            }

            return sb.ToString().GetHashCode();
        }
        private static int[] CreateArray(string s)
        {
            int[] ret = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var index = c - 'a';
                ret[index]++;
            }

            return ret;
        }


        static void Main(string[] args)
        {
            var test = GroupAnagrams(new[] {"abbbbbbbbbbb","aaaaaaaaaaab"});
            Console.ReadKey();
        }
    }
}