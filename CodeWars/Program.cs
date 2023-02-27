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
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] <= nums[right]) return nums[left];

                int mid = (left + right) / 2;
                if (nums[mid] >= nums[left])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return 0;
        }

        public static int Search(int[] nums, int target)
        {
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
            var q = FindMin(new[] {4, 5, 6, 7, 0, 1, 2});
            Console.ReadKey();
        }
    }
}