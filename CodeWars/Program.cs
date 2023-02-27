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

        public static bool SearchMatrix(int[][] matrix, int target) {
            if (matrix.Length == 1)
            {
                return Search(matrix.First(), target) != -1;
            }
            int left = 0;
            int right = matrix.Length;
            int targetArray = right - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (mid >= matrix.Length) break;
                int firstVal = matrix[mid][0];
                if (target == firstVal) return true;
                if (mid == 0)
                {
                    if (firstVal <= target)
                    {
                        targetArray = 0;
                        break;
                    }

                    return false;
                }

                var firstPrevVal = matrix[mid - 1][0];
                if (target < firstVal && target >= firstPrevVal)
                {
                    targetArray = mid - 1;
                    break;
                }

              
                if (target > firstVal)
                {
                    left = mid + 1;
                }

                if (target < firstVal)
                {
                    right = mid - 1;
                }
            }

            var search = Search(matrix[targetArray], target);
            return search != -1;
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
            var q = SearchMatrix(new []{new []{1}, new []{3}}, 4);
            Console.ReadKey();
        }
    }
}