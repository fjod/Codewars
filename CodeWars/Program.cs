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
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            int counter = 0;
            var leftSum = word1.Aggregate(0, (i, s) => i + s.Length);
            var rightSum = word2.Aggregate(0, (i, s) => i + s.Length);
            if (leftSum != rightSum) return false;
            while (true)
            {
                var left = GetCharByIndex(word1, counter);
                if (!left.Item2) return false;
                
                var right = GetCharByIndex(word2, counter);
                if (!right.Item2) return false;

                if (left.Item1 != right.Item1) return false;

                counter++;
                if (counter == leftSum) return true;
            }
            
        }

        static (char, bool) GetCharByIndex(string[] words, int index)
        {
            int wordIndex = 0;
            while (true)
            {
                if (wordIndex == words.Length) return (' ', false);
                var word = words[wordIndex];
                if (index < word.Length) return (word[index], true);
                index -= word.Length;
                wordIndex++;
            }
        }


        static void Main(string[] args)
        {
            var test = ArrayStringsAreEqual( new[] {"abc", "d", "defg"}, new[] {"abcddefg"});
            Console.ReadKey();
        }
    }
}