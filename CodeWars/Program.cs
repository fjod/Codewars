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
        public static int PassThePillow(int n, int time)
        {
            if (n == 2)
            {
                if (time % 2 == 0) return 1;
                else return 2;
            }
            if (time < n) return time + 1;
            if (time == n) return n - 1;
            bool forward = true;
            while (true)
            {
                time = time - (n - 1);
                forward = !forward;
                if (time < n && !forward) 
                    return n - time;
                if (time < n && forward) 
                    return time + 1;
                if (time == n) 
                    return n - 1;   
            }
        }

       


        static void Main(string[] args)
        {
            var test = PassThePillow( 2, 341);
            Console.ReadKey();
        }
    }
}