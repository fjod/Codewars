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
            public int CountBalls(int lowLimit, int highLimit)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = lowLimit; i <= highLimit; i++)
                {
                    int sum = 0;
                    int num = i;
                    while (num > 0)
                    {
                        sum += num % 10;
                        num /= 10;
                    }

                    if (map.ContainsKey(sum))
                    {
                        map[sum]++;
                    }
                    else
                    {
                        map.Add(sum, 1);
                    }
                }
                return map.Values.Max();
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                Console.WriteLine(ColoredCells(3));
            }
        }
    }
}