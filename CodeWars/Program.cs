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
            public int LargestAltitude(int[] gain)
            {
                int current = 0;
                int max = int.MinValue;
                for (int i = 0; i < gain.Length; i++)
                {
                    current = current + gain[i];
                    max = Math.Max(max, current);
                }
                
                return Math.Max(max, 0);
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = MaxScore("0100");
            }
        }
    }
}