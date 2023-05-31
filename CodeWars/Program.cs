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
            public bool WordPattern(string pattern, string s)
            {
                var splitted = s.Split(' ');
                var dict = new Dictionary<char, string>();
                if (splitted.Length != pattern.Length) return false;
                for (var i = 0; i < pattern.Length; i++)
                {
                    var currentChar = pattern[i];
                    var currentWord = splitted[i];
                    if (!dict.ContainsKey(currentChar))
                    {
                        if (dict.ContainsValue(currentWord)) return false;
                        dict.Add(currentChar, currentWord);
                    }
                    else
                    {
                        if (dict[currentChar] != currentWord) return false;
                    }
                }

                return true;
            }

            static void Main(string[] args)
            {
                var arr = DistanceBetweenBusStops(new []{7,10,1,12,11,14,5,0}, 7 , 2);
            }
        }
    }
}