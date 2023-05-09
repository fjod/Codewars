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

        //still need more practice with backtracking
        public static int SubsetXORSum(int[] nums)
        {
         return helper(nums, 0, 0);
        }

        private static int helper(int[] nums, int index, int currentXor)
        {
            if (index == nums.Length) return currentXor;

            var withCurrent = helper(nums, index + 1, currentXor ^ nums[index]);
            var withoutCurrent = helper(nums, index + 1, currentXor);
            return withCurrent + withoutCurrent;
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = SubsetXORSum(new[] {5 ,1, 6});
            q = SubsetXORSum(new[] {5 , 1, 6});
        }
    }
}