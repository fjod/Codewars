using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int[] SearchRange(int[] nums, int target)
        {

            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    return new[] {0, 0};
                }
                return new[] {-1, -1};
            }
            List<int> ret = new List<int>();
            int left = 0;
            int right = nums.Length - 1;
            
            while (left <= right)
            {
                int mid = (left + right)/2;
                if (nums[mid] == target)
                { //search left and right for termination
                    int l = mid;
                    int r = mid;
                    while (l >= 0 && nums[l] == target)
                    {
                        l--;
                    }
                    while (r < nums.Length && nums[r] == target)
                    {
                        r++;
                    }

                    ret.Add(l+1);
                    ret.Add(r-1);
                    return ret.ToArray();
                }
                else if (nums[mid] < target)
                {
                    left = mid+ 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
            ret.Add(-1);
            ret.Add(-1);
            return ret.ToArray();
        }

        static void Main(string[] args)
        {
            var q = SearchRange(new []{2,2}, 2);
        }
    }
}