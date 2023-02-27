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

        public static int MinEatingSpeed(int[] piles, int h)
        {
            if (h <= piles.Length) return piles.Max();
            int minSpeed = 0;
            int left = 1;
            int right = piles.Max();
            while (left < right)
            {
                int mid = (left + right) / 2;
                var eatingSpeed = mid;
                long currentTotal = 0;
                for (int i = 0; i < piles.Length; i++)
                {
                    currentTotal += (int)Math.Ceiling((double)piles[i] / eatingSpeed);
                }

                if (currentTotal <= h)
                {
                    minSpeed = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
                
            }

            return minSpeed;
        }
        
        public static int Search(int[] nums, int target) {
          
            int left = 0;
            int right = nums.Length - 1;
            
            if (nums.Length == 1)
            {
                if (nums[0] == target) return 0;
                return -1;
            }

            while (left <= right)
            {
                int mid = (right + left) / 2;
                int val = nums[mid];
                if (val == target)
                {
                    return mid;
                }
                
                if (val < target)
                {
                    left = mid + 1;
                }

                if (val > target)
                {
                    right = mid - 1;
                }
            }

            return -1;
        }


        static void Main(string[] args)
        {
            var q = MinEatingSpeed(new []{805306368,805306368,805306368}, 1000000000);
            Console.ReadKey();
        }
    }
}