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
            IsPalindrome(121);
            Console.Write(1);
        }
       
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x !=0 && x%10==0) return false;
            int reverse = 0;
            while ( x > reverse)
            {
                reverse = reverse * 10 + x % 10;
                x = x / 10;
            }

            return x == reverse || x == reverse / 10;
        }
    }
}