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
        public int MyAtoi(string s)
        {
            int sign = 1;
            var trimmed = s.Trim();
            if (trimmed.StartsWith('-'))
            {
                sign = -1;
                s = s.Substring(1);
            }

            if (trimmed.StartsWith('+'))
            {
                s = s.Substring(1);
            }

            string conv = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c >= '0' && c <= '9')
                {
                    conv += c;
                }
            }

            if (conv.Length == 0)
            {
                return 0;
            }

            conv = conv.TrimStart('0');
            var parsed = long.Parse(conv) * sign;
            if (parsed > int.MaxValue)
            {
                return int.MaxValue;
            }
            if (parsed < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)parsed;
        }



        static void Main(string[] args)
        {
            var q = Convert("PAYPALISHIRING", 3);
        }
    }
}