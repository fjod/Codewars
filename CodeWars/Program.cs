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
        //161 / 311 testcases passed
        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            if (num1 == "1") return num2;
            if (num2 == "1") return num1;

            var longerString = num1.Length > num2.Length ? num1 : num2;
            var shortertString = num1.Length < num2.Length ? num1 : num2;
            if (num1.Length == num2.Length)
            {
                longerString = num1;
                shortertString = num2;
            }

            Int64 sum = 0;
            for (int i = longerString.Length - 1; i >= 0; i--)
            {
                var longerDigit = longerString[i];
                for (int j = shortertString.Length - 1; j >= 0; j--)
                {
                    var shorterDigit = shortertString[j];
                    Int64 product = (longerDigit - '0') * (shorterDigit - '0');
                    if (i != longerString.Length - 1) product *= (Int64)Math.Pow(10,(longerString.Length - 1 - i));
                    if (j != shortertString.Length - 1) product *= (Int64)Math.Pow(10, shortertString.Length - 1 - j);
                    sum += product;
                }
            }

            return sum.ToString();
        }

         public static string Multiply1(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") { return "0"; }
            var MAX_RADIX = 1000000000;
            var RADIX_LENGTH = 9;

            var num1Value = new long[num1.Length / RADIX_LENGTH + 1];
            var num2Value = new long[num2.Length / RADIX_LENGTH + 1];

            int i, j, temp, data, index = 0;
            for (i = num1.Length; i > 0; i -= RADIX_LENGTH)
            {
                data = 0;
                temp = i > RADIX_LENGTH ? i - RADIX_LENGTH : 0;
                for (j = temp; j < i; j++)
                {
                    data = data * 10 + (num1[j] - '0');
                }
                num1Value[index++] = data;
            }
            index = 0;
            for (i = num2.Length; i > 0; i -= RADIX_LENGTH)
            {
                data = 0;
                temp = i > RADIX_LENGTH ? i - RADIX_LENGTH : 0;
                for (j = temp; j < i; j++)
                {
                    data = data * 10 + (num2[j] - '0');
                }
                num2Value[index++] = data;
            }

            var resultValue = new long[num1Value.Length + num2Value.Length];
            for (i = 0; i < num1Value.Length; i++)
            {
                for (j = 0; j < num2Value.Length; j++)
                {
                    resultValue[i + j] += num1Value[i] * num2Value[j];
                    if (resultValue[i + j] >= MAX_RADIX)
                    {
                        resultValue[i + j + 1] += resultValue[i + j] / MAX_RADIX;
                        resultValue[i + j] = resultValue[i + j] % MAX_RADIX;
                    }
                }
            }

            var builder = new StringBuilder();
            var tempStr = string.Empty;
            var started = false;
            for (i = resultValue.Length - 1; i >= 0; i--)
            {
                if (resultValue[i] != 0)
                {
                    tempStr = resultValue[i].ToString();
                    if (started)
                    {
                        builder.Append('0', 9 - tempStr.Length);
                    }
                    builder.Append(resultValue[i].ToString());
                    started = true;
                }
            }

            return builder.ToString();
        }

        static void Main(string[] args)
        {
            var q = Multiply1("498828660196", "840477629533");
        }
    }
}