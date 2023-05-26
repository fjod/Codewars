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
            public string TruncateSentence(string s, int k)
            {
                int spaces = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var current = s[i];
                    if (current == ' ')
                    {
                        spaces++;
                    }

                    if (spaces == k)
                    {
                        return s.Substring(0, i);
                    }
                }
                return s;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = MaxScore("0100");
            }
        }
    }
}