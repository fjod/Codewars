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
        public int MostWordsFound(string[] sentences)
        {

            return sentences.Select(s => s.Count(inner => inner == ' ') + 1).Max();
        }

       


        static void Main(string[] args)
        {
            var test = PassThePillow( 2, 341);
            Console.ReadKey();
        }
    }
}