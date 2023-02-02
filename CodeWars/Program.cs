using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        
        public static int Compress(char[] chars)
        {
            string ret = String.Empty;

            char prev = chars[0];
            int currentAmount = 1;
            if (chars.Length == 1) ret += chars[0];

            for (int i = 1; i < chars.Length; i++)
            {
                var current = chars[i];
                if (current != prev) //new char
                {
                    ret += prev;
                    if (currentAmount != 1)
                    {
                        ret += currentAmount;
                    }

                    prev = current;
                    currentAmount = 1;
                    if (i == chars.Length - 1)
                    {
                        ret += prev;
                    }
                }
                else
                {
                    currentAmount++;
                    if (i == chars.Length - 1)
                    {
                        ret += prev;
                        if (currentAmount > 1) ret += currentAmount;
                    }
                }
            }
            

            for (var i = 0; i < ret.Length; i++)
            {
                chars[i] = ret[i];
            }

            return ret.Length;
        }
        static void Main(string[] args)
        {
            var q = Compress(new []{'a','b','c'});
            Console.ReadKey();
        }
    }
}