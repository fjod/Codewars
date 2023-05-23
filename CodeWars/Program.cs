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
            public static long ColoredCells(int n)
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                if (n == 2) return 5;
                
                // n >= 3
                long horizontal = n - 2;
                long center = 1;
                long leftOverSides = 4;
                long ladder = 0;
                for (long i = 1; i <= horizontal; i++)
                {
                    ladder += i;
                }

                return horizontal * 4 + center + leftOverSides + ladder * 4;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                Console.WriteLine(ColoredCells(3));
            }
        }
    }
}