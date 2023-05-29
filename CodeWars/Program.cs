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
            public static bool IsAlienSorted(string[] words, string order) {

                for (int i = 1; i < words.Length; i++)
                {
                    var prev = words[i - 1];
                    var curr = words[i];
                    for (int j = 0; j < prev.Length; j++)
                    {
                        var prevChar = prev[j];
                        if (j >= curr.Length)return false;
                        var currChar = curr[j];
                        if (prevChar != currChar)
                        {
                            if (order.IndexOf(prevChar) > order.IndexOf(currChar)) return false;
                            break;
                        }
                    }
                }

                return true;
            }

            static void Main(string[] args)
            {
                var arr = IsAlienSorted(new []{"apple", "app"}, "abcdefghijklmnopqrstuvwxyz");
            }
        }
    }
}