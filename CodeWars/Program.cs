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

        public static int MaxArea(int[] height)
        {

            int left = 0;
            int right = height.Length - 1;
            int maxVolume = 0;
            while (left < right)
            {
                var currentHeight = Math.Min(height[left], height[right]);
                var currentVolume = (right - left) * currentHeight;
                maxVolume = Math.Max(maxVolume, currentVolume);
                if (height[left] < height[right]) left++;
                else right--;
            }

            return maxVolume;

        }


        static void Main(string[] args)
        {
            var q = MaxArea(new[] {1,8,6,2,5,4,8,3,7});
            Console.ReadKey();
        }
    }
}