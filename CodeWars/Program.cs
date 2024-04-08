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
            Console.Write(1);
        }

        public int BalancedStringSplit(string s)
        {
            int r = 0;
            int l = 0;
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (r > 0 && l > 0 && r == l)
                {
                    total += 1;
                    r = 0;
                    l = 0;
                }

                if (s[i] == 'R')
                {
                    r++;
                }
                if (s[i] == 'L')
                {
                    l++;
                }
            }

            if (r > 0 && l > 0 && r == l)
            {
                total += 1;
            }
            return total;
        }
        
      
    }
}