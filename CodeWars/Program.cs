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
        public static int GetMaximumGenerated(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            var nums = new int[n + 1];
            nums[0] = 0;
            nums[1] = 1;
            for (int i = 2; i < n + 1; i++)
            {
                if (i%2 == 0) nums[i] = nums[i/2];
                else
                {
                    nums[i] = nums[i/2] + nums[i/2 + 1];    
                }
                
            }
            
            return nums.Max();
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = GetMaximumGenerated(7);
         
        }
    }
}