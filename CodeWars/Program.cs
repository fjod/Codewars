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
            public static int MaxScore(string s)
            {
                var amountOfOnes = s.Count(c => c == '1');
                if (amountOfOnes == s.Length) return amountOfOnes - 1;
                if (amountOfOnes == 0) return s.Length - 1;
                
                var max = int.MinValue;
                var amountOfZeroes = 0;
              
                for (var i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == '0')
                    {
                        amountOfZeroes++;
                    }
                    else
                    {
                        amountOfOnes--;
                    }
                    max = Math.Max(max, amountOfZeroes + amountOfOnes);
                }

                return max;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = MaxScore("0100");
            }
        }
    }
}