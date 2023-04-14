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
        
        public int[] CountBits(int n)
        {

            int[] ret = new int[n+1];
            for (int i = 0; i < n+1; i++)
            {
                var asBin = Convert.ToString(i, 2);
                ret[i] = asBin.Count(s => s == '1');
                ret[i] = solve(i);
            }

            return ret;
        }
        
        public int solve(int n){
            // base condition
            if(n == 0) return 0;
            if(n == 1) return 1;
        
            if(n % 2 == 0) return solve(n / 2); // handling even case
            else return 1 + solve(n / 2); // handling odd case
        }
    }


        static void Main(string[] args)
        {
        
        }
    }
}