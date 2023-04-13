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
        public static int[] PlusOne(int[] digits) {

            if (digits[^1] != 9)
            {
                digits[^1] = digits[^1] + 1;
                return digits;
            }

            int[] newDigs = new int[digits.Length + 1];
            for (int i = 0; i < digits.Length; i++)
            {
                newDigs[i + 1] = digits[i];
            }
            newDigs[^1] = 0;
            for (int i = newDigs.Length - 2; i >= 0; i--)
            {
                if (newDigs[i] != 9)
                {
                    newDigs[i] = newDigs[i] + 1;
                    if (newDigs.First() == 0) return newDigs.Skip(1).ToArray();
                    return newDigs;
                }
                else
                {
                    newDigs[i] = 0;
                }
            }

            if (newDigs.First() == 0) return newDigs.Skip(1).ToArray();
            return newDigs;
        }


        static void Main(string[] args)
        {
            var test = PlusOne( new []{9});
            Console.ReadKey();
        }
    }
}