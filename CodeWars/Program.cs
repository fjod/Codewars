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
        public static string Interpret(string command)
        {
            return command.Replace("()", "o").Replace("(al)", "al");
        }


        static void Main(string[] args)
        {
            var test = MaxRepeating( "aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba");
            Console.ReadKey();
        }
    }
}