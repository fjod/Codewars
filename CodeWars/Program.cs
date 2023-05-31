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
        public class Solution
        {
            public class NumArray
            {
                private int[] _nums;

                public NumArray(int[] nums)
                {
                    _nums = new int[nums.Length];
                    _nums[0] = nums[0];
                    for (int i = 1; i < nums.Length; ++i)
                        _nums[i] = _nums[i - 1] + nums[i];
                }

                public int SumRange(int left, int right)
                {
                    var leftSum = _nums[right];
                    if (left == 0) return leftSum;
                    return leftSum - _nums[left - 1];
                }
            }

            static void Main(string[] args)
            {
                var test = new NumArray(new[] {-2, 0, 3, -5, 2, -1});
                test.SumRange(0, 2);
            }
        }
    }
}