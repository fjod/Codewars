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
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            
                return TryBreak(s, wordDict);
            
        }

        private static Dictionary<string, bool> dict = new Dictionary<string, bool>();
        private static bool TryBreak(string s, IList<string> wordDict)
        {
            if (dict.ContainsKey(s)) return false;
            if (string.IsNullOrEmpty(s)) return true;
            string word = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                word += s[i];
                if (wordDict.Any(w => w == word))
                {
                    if (TryBreak(s.Substring(word.Length), wordDict)) return true;
                }
            }

            dict.Add(s, false);
            return false;
        }


        static void Main(string[] args)
        {
            var test = WordBreak("applepenapple", new List<string>(){"apple","pen"});
            Console.ReadKey();
        }
    }
}