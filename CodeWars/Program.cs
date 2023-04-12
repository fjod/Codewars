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
        public static int MaxRepeating(string sequence, string word)
        {
            int ret=0;
            string w=word;
            while(sequence.Contains(w, StringComparison.Ordinal))
            {
                w+=word;
                ret++;
            }
        
            return ret;
        }


        static void Main(string[] args)
        {
            var test = MaxRepeating( "aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba");
            Console.ReadKey();
        }
    }
}