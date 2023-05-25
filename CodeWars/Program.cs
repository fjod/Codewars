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
            public static int TitleToNumber(string columnTitle)
            {
                int ret = 0;
                int current = 0;
                foreach (var c in columnTitle.Reverse())
                {
                    var weight = c - 'A' + 1;
                    ret += weight * (int)Math.Pow(26, current);
                    current++;
                }

                return ret;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = TitleToNumber("ZY");
            }
        }
    }
}