using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
   
    class Program
    {
        /// <summary>
        /// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int min = 0;
            int max = nums.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                var current = nums[mid];
                if (target == current)
                {
                    return mid;
                }
                // середина больше цели, ищем в левой половине
                if (current > target)
                {
                    // mid уже проверен, нужно смещаться в сторону от него
                    max = mid - 1;
                }
                // середина меньше цели, ищем в правой половине
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }
        
        public static int MySqrt(int x)
        {
            if (x <= 1) return x;
            int left = 1;
            int right = x ;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                long mult = (long)mid * mid;
                if (mult == x) return (int)mid;
                if (mult < x) left = (int)mid + 1;
                if (mult > x) right = (int)mid - 1;
            }

            return right;
        }

        public static int BinSearch(int[] nums, int target)
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
                int mid = left + (right - left) / 2;
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

        public static int FindPivot(int[] nums)
        {
            int left = 0;
            int right = nums.Length;
           

            while (left < right)
            {
                int mid = (left + right) / 2;
                int numValue = nums[mid];
                if (mid + 1 == nums.Length)
                {
                    if (nums.Length == 2 && nums[0] > nums[1]) return 1;
                    if (nums.Length == 2 && nums[0] < nums[1]) return 0;
                    return -1;
                }
                int numNextValue = nums[mid + 1];
                if (numValue > nums[left])
                {
                    // search on right side [4,6, _7_,8,1,2,3]
                    left = mid;
                }
                else
                {
                    //[8,9,10,1,_2_,3,4,5,6,7]
                    right = mid;
                }

                if (numValue > numNextValue) return mid;
            }

            return -1;
        }
        public static int BinSearchForPivoted(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                if (nums[0] == target) return 0;
                return -1;
            }
            
            if (nums.Length == 2)
            {
                if (nums[0] == target) return 0;
                if (nums[1] == target) return 1;
                return -1;
            }
            
            // find element which marks shifted array
            int pivotIndex = FindPivot(nums);
            if (pivotIndex == -1)
            {
               return BinSearch(nums, target);
            }
            int pivotValue = nums[pivotIndex];
            if (target == pivotValue) return pivotIndex;
            if (target >= nums[0] && target <= pivotValue)
            {
                int search = BinSearch(nums.AsSpan().Slice(0, pivotIndex).ToArray(), target);
                return search == -1 ? -1 : search ;
            }
            
            int search2 = BinSearch(nums.AsSpan().Slice(pivotIndex + 1, nums.Length - pivotIndex - 1).ToArray(), target);
            return search2 == -1 ? -1 : search2  + pivotIndex + 1;
        }

        static void Main(string[] args)
        {
            var p = BinSearchForPivoted(new[] {5, 6, 7, 8, 9, 10 ,11, 1, 2, 3, 4}, 9);
            p = BinSearchForPivoted(new[] {4,5,6,7,0,1,2}, 0);
            
            p = BinSearchForPivoted(new[] {3, 5, 1}, 3);
            var z = BinSearch(new[] {-1,0,3,5,9,12}, 9);
            var a = BinSearchForPivoted(new[] {4, 5, 6, 7, 0, 1, 2}, 0);
            var q = MySqrt(53);
        }
    }
}
