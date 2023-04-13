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
        
        public static string ConvertToTitle(int columnNumber)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder();
            while (columnNumber > 0)
            {
                columnNumber--;

                var d = columnNumber % 26;
                sb.Insert(0, chars[d]);
                columnNumber /= 26;
            }

            return sb.ToString();
        }

        

        static void Main(string[] args)
        {
            var q = ConvertToTitle(27);
            Console.ReadKey();
        }
    }
}