using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace CodeWars
{
    class Program
    {
        
        public static bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!dictionary.ContainsKey(c)) dictionary.Add(c, 1);
                else dictionary[c] += 1;
            }

            foreach (var c in t)
            {
                if (!dictionary.ContainsKey(c)) return false;
                dictionary[c] -= 1;
                if (dictionary[c] < 0) return false;
            }

            return dictionary.Values.All(v => v == 0);
        }
        
     

        static void Main(string[] args)
        {
            var test = IsAnagram("anagram", "nagaram");
            Console.ReadKey();
        }
    }
}