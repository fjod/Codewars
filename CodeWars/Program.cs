using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static int NTrib(int n)
        {
            
            int[] res = new int[n+3];
            res[0] = 0;
            res[1] = 1;
            res[2] = 1;
            if (n < 3) return res[n];
            for (int i = 3; i < n+1; i++)
            {
                res[i] = res[i - 1] + res[i - 2] + res[i - 3];
            }

            return res[n];
        }

        static void Main(string[] args)
        {
            var q = NTrib(2);
            Console.ReadKey();
        }
    }
}