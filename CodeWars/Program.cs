using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        public class Solution
        {
            public static int CountVowelStrings(int n)
            {
                List<int> vowels = new List<int> {1,1,1,1,1};
                if (n == 0) return 0;
                if (n == 1) return 5;
              
                for (int i = 2; i <= n; i++)
                {
                    vowels[0]=vowels[0]+vowels[1]+vowels[2]+vowels[3]+vowels[4];
                    vowels[1]=vowels[1]+vowels[2]+vowels[3]+vowels[4];
                    vowels[2]=vowels[2]+vowels[3]+vowels[4];
                    vowels[3]=vowels[3]+vowels[4];       
                }

                return vowels.Sum();
            }
            
            // bruteforce exceeds time limit for 35
            public int CountVowelStrings2(int n) {
                List<string> vowels = new List<string> {"a","e","i","o","u"};
                if (n == 0) return 0;
                if (n == 1) return 5;
                var result = 0;
                for (int i = 2; i <= n; i++)
                {
                    vowels = CountVowelStrings(vowels);
                    result = vowels.Count;
                }

                return result;
            }

            private  List<string> CountVowelStrings(List<string> input)
            {
                List<string> temp = new List<string>();
                List<string> zero = new List<string> {"a","e","i","o","u"};
                for (int i = 0; i < zero.Count; i++)
                {
                    var vowel = zero[i];
                    for (int j = 0; j < input.Count; j++)
                    {
                        var prevVowel = input[j];
                        if (prevVowel.Last() <= vowel.First())
                        {
                            temp.Add(prevVowel + vowel);
                        }
                    }
                }

                return temp;
            }

          

            static void Main(string[] args)
            {
                // var q = MaxProfit(new []{7,1,5,3,6,4});
                var q = CountVowelStrings(32);
            }
        }
    }
}