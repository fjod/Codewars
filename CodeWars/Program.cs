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
        static void Main(string[] args)
        {
            var l2 = MinimumSum(2932);
            Console.Write(1);
        }

        public static int MinimumSum(int num)
        {
            List<int> numbers = new List<int>(4);
            numbers.AddRange(GetDigits2(num).ToList().OrderDescending().Reverse());
            int n1 = numbers[0]*10 + numbers[3];
            int n2 = numbers[1]*10 + numbers[2];

            int n3 = numbers[0] * 10 + numbers[2];
            int n4 = numbers[1]*10 + numbers[3];

            var q1 = n1 + n2;
            var q2 = n3 + n4;
            return q1 > q2 ? q2 : q1;
        }
        
        public static IEnumerable<int> GetDigits2(int source)
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
        }
    }
}