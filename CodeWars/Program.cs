using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace CodeWars
{
   
    class Program
    {
        public double Average(int[] salary)
        {
            return salary.OrderBy(m => m).Skip(1).Take(salary.Length - 2).Average();
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}

