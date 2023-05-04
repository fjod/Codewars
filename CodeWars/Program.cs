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

namespace CodeWars
{
    class Program
    {

        public static int MaxProfit(int[] prices)
        {
            // if there are many days, we can just sum them one by one
            var maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
                maxProfit += Math.Max(0, prices[i] - prices[i - 1]);

            return maxProfit;

        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = MaxProfit(new[] {1, 2, 3, 4, 5});
        }
    }
}