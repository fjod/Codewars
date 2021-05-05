using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace CodeWars
{
   
    class Program
    {
        static IEnumerable<int> CalcFactorsForNumber(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0) yield return j;
            }
        }
        static int KthFactor(int n, int k)
        {
            int count = 1;
            foreach (var VARIABLE in CalcFactorsForNumber(n))
            {
                if (count == k) return VARIABLE;
                count++;
            }

            return -1;
        }
        static void Main(string[] args)
        {
            var q = KthFactor(4, 4);
            Console.ReadKey();
        }
    }
}

