using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {

            if (gas.Sum() < cost.Sum()) return -1;
            int ret = 0;
            int total = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];
                if (total < 0) // если текущая сумма < 0, то начинать надо не отсюда (дальше не уедем)
                {
                    ret = i + 1;
                    total = 0;
                }
            }

            return ret;
        }
        
        static void Main(string[] args)
        {
            var q = CanCompleteCircuit(new[] {2, 3, 1, 1, 4});

            Console.ReadKey();
        }
    }
}