using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeWars
{
    class Program
    
    {
        
        public bool IsPalindrome(int x) {
            var s = x.ToString().Reverse();
            StringBuilder sb = new StringBuilder();
            foreach (var VARIABLE in s)
            {
                sb.Append(VARIABLE);
            }
            var ret = sb.ToString() == x.ToString();
            return ret;
        }
        
        static void Main(string[] args)
        {
            var q = Reverse(-2147483648);
            Console.ReadKey();
        }
    }
}