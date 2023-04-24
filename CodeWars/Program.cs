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
        public static void SortColors(int[] nums)
        {
            int zeroes = 0;
            int ones = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                switch (nums[i])
                {
                    case 0:
                    {
                        zeroes++;
                        break;
                    }
                    case 1:
                    {
                        ones++;
                        break;
                    }
                }
            }

            for (int i = 0; i < zeroes; i++)
            {
                nums[i] = 0;
            }
            
            for (int i = zeroes ; i < zeroes + ones; i++)
            {
               nums[i] = 1;
            }
            
            for (int i = zeroes + ones; i < nums.Length; i++)
            {
                nums[i] = 2;
            }
        }

        static void Main(string[] args)
        {
            var test = new[] {2, 0, 2, 1, 1, 0};
            SortColors(test);
        }
    }
}