using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Threading;

namespace CodeWars
{
    class Program
    {

        public static string ConvertSpaces(string input, int l)
        {
            var conv = "%20";
            bool lastCharWasConverted = false;
            string ret = string.Empty;
            if (input[0] == ' ')
            {
                lastCharWasConverted = true;
                ret += conv;
            }
            else
            {
                lastCharWasConverted = false;
                ret += input[0];
            }
            for (int i = 1; i < l; i++)
            {
                if (input[i] == ' ' && lastCharWasConverted)
                {
                    continue;
                }
                if (input[i] == ' ' && !lastCharWasConverted)
                {
                    lastCharWasConverted = true;
                    ret += conv;
                }
                else
                {
                    lastCharWasConverted = false;
                    ret += input[i];
                }
            }

            return ret;
        }

        static void Main(string[] args)
        {
            var q = ConvertSpaces("Mr John Smith    ", 13);
            Console.ReadKey();
        }
    }
}