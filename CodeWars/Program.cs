using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int[] ProductExceptSelf(int[] nums) {
            int prefix = 1, postfix = 1;
            int[] prefixArr = new int[nums.Length];        
            int[] postFixArr = new int[nums.Length];
            
            for(int i = 0; i < nums.Length; i++){
                prefixArr[i] = prefix;
                prefix *= nums[i];
            }
        
            for(int i = nums.Length-1; i>=0; i--){
                postfix *= nums[i];
                postFixArr[i] = postfix;
            }

            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                var prevVal = i - 1 < 0 ? 1 : prefixArr[i];
                var nextVal = i + 1 == nums.Length ? 1 : postFixArr[i+1];
                res[i] = prevVal * nextVal;
            }

            return res;
        }


        static void Main(string[] args)
        {
            var test = ProductExceptSelf(new[] {1,2, 3, 4});
            Console.ReadKey();
        }
    }
}