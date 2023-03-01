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
        public static int CharacterReplacement(string s, int k)
        {
            int left = 0;
            int right = 0;
            int max = 0;
            Dictionary<char, int> dictionary = new Dictionary<char, int>(26);
            for (int i = 0; i < s.Length; i++)
            {
                if (!dictionary.ContainsKey(s[i])) dictionary.Add(s[i], 1);
                else dictionary[s[i]] += 1;
                var otherLetters = dictionary.MaxBy(d => d.Value);
               
                
                if (right - left + 1 - otherLetters.Value> k){
                    dictionary[s[left]] -= 1;
                    left++;
                }
                max = Math.Max(right - left + 1, max);
                right++;
            }

            return max;

        }


        static void Main(string[] args)
        {
            var q = CharacterReplacement("BAAA", 0);
            Console.ReadKey();
        }
    }
}