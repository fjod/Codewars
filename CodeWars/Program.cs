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

        // I tried to solve it with binary search, but it failed for some reason
        public static int[] TwoSum(int[] numbers, int target) {

            // Using 2 pointers. Since sorted, if l+r > target, decrease r.
            // Else if l+r < target, increase l. Else, result is found.
            int left = 0, right = numbers.Length - 1;

            while (left < right) {
                int sum = numbers[left] + numbers[right];
                if (sum > target) {
                    right--;
                } else if (sum < target) {
                    left++;
                } else {
                    return new int[] {left + 1, right + 1};
                }
            }

            return new int[0];
        }
        


        static void Main(string[] args)
        {
            var q = TwoSum(new []{5,25,75}, 100);
            Console.ReadKey();
        }
    }
}