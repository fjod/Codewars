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
            public int FinalValueAfterOperations(string[] operations)
            {
                int i = 0;
                foreach (var s in operations)
                {
                    i = calc(s, i);
                }

                return i;
            }

            int calc(string input, int i)
            {
                return input switch
                {
                    "--X" => i - 1,
                    "X--" => i - 1,
                    "++X" => i + 1,
                    "X++" => i + 1,
                    _ => i
                };
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                Console.WriteLine(ColoredCells(3));
            }
        }
    }
}