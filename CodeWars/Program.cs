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
        static void Main(string[] args)
        {
            var test = LongestCommonPrefix(new string[] {"flower", "flower"});
            Console.Write(1);
        }
       
        public static string LongestCommonPrefix(string[] strs)
        {
            if (!strs.Any()) return "";
            if (strs.Length == 1) return strs[0];
            
            var shortest = strs.Min(s => s.Length);
            if (shortest == 0) return "";
            var charIndex = 0;
            var prefix = strs[0][charIndex].ToString();
            while (true)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    var current = strs[i];
                    if (!current.StartsWith(prefix))
                    {
                        return prefix.Length > 0 ? prefix.Substring(0, prefix.Length - 1) : String.Empty;
                    }
                }
                charIndex++;
                if (charIndex == shortest)
                    break;
                prefix += strs[0][charIndex].ToString();
            }

            return prefix;
        }
    }
}