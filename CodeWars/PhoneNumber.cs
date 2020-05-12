using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public static class PhoneNumber
    {
        public static string Create(int[] input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");

            sb.Append(FromIntToString(input.Take(3)));
            sb.Append(") ");
            sb.Append(FromIntToString(input.Skip(3).Take(3)));
            sb.Append("-");
            sb.Append(FromIntToString(input.Skip(6).Take(4)));
            return sb.ToString();
        }

        static string FromIntToString(IEnumerable<int> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in input)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }
    }

    public static class BetterSolution //not my ofc
    {
        private const string PhoneNumberFormat = @"({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}";

        public static string CreatePhoneNumber(int[] numbers)
        {
            if(numbers.Length > 10)
            {
                throw new ArgumentException("More than ten numbers contained in the array");
            }

            return string.Format(PhoneNumberFormat, numbers.Select(x => x.ToString()).ToArray());
        }
    }
}