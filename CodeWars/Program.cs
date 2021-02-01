using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeWars
{
    class Program
    
    {
        
        public static int Reverse(int x) {
            bool isNegative = x < 0;
            
            var s = x.ToString().Replace('-',' ').Reverse();
            StringBuilder sb = new StringBuilder();
            foreach (var VARIABLE in s)
            {
                sb.Append(VARIABLE);
            }

            try
            {
                int res1 = Int32.Parse(sb.ToString());
                if (isNegative) return -1 * res1;
            
                return res1;
            }
            catch (OverflowException e)
            {
                return 0;
            }
          
           
        }
        
        static void Main(string[] args)
        {
            var q = Reverse(-2147483648);
            Console.ReadKey();
        }
    }
}