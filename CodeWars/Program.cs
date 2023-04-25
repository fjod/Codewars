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
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static IList<string> RestoreIpAddresses(string s) {
        
                List<string> result = new List<string>();
            RestoreIpAddresses2(s, 0, "", result);
            return result;
        }

        private static void RestoreIpAddresses2(string input, int digitsAmount, string current, List<string> result)
        {
            if (digitsAmount == 4 && input.Length == 0)
            {
                result.Add(current);
                return;
            }

            if (digitsAmount == 4) return;

            if (input.Length < 1) return;
            var one = input.First();
           
                string temp1 = "";
                if (current == string.Empty) temp1 = one.ToString();
                else
                {
                    temp1 = current + $".{one}";
                }

                RestoreIpAddresses2(input.Substring(1), digitsAmount + 1, temp1, result);
            

            if (input.Length < 2) return;
            var two = int.Parse(input.Substring(0, 2));
            if (two >= 10 && two <= 99)
            {
                string temp = "";
                if (current == string.Empty) temp = two.ToString();
                else
                {
                    temp = current + $".{two}";
                }

                RestoreIpAddresses2(input.Substring(2), digitsAmount + 1, temp, result);
            }

            if (input.Length < 3) return;
            var three = int.Parse(input.Substring(0, 3));
            if (three >= 100 && three <= 255)
            {
                string temp = "";
                if (current == string.Empty) temp = three.ToString();
                else
                {
                    temp = current + $".{three}";
                }

                RestoreIpAddresses2(input.Substring(3), digitsAmount + 1, temp, result);
            }
        }

        static void Main(string[] args)
        {
            var test = RestoreIpAddresses("25525511135");
        }
    }
}