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
        public int MaximumWealth(int[][] accounts)
        {
            return accounts.Max(acc => acc.Sum());
        }


        static void Main(string[] args)
        {
            var test = MaxRepeating( "aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba");
            Console.ReadKey();
        }
    }
}