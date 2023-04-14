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
        
        public static bool IsHappy(int n)
        {

            HashSet<string> hashSet = new HashSet<string>();
            while (true)
            {
                var sum = 0;
                var s = n.ToString();
                if (hashSet.Contains(s)) return false;
                foreach (var c in s)
                {
                    var v = int.Parse(c.ToString());
                    sum += v * v;
                }

                if (sum == 1) return true;
                hashSet.Add(s);
                n = sum;
            }
        }

        

        static void Main(string[] args)
        {
            var q = IsHappy(2);
            Console.ReadKey();
        }
    }
}