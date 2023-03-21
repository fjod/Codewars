using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool CheckValidString(string s)
        {
            var leftMax = 0;
            var leftMin = 0;

            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    leftMin++;
                    leftMax++;
                }
                else if (ch == ')')
                {
                    leftMax--;
                    leftMin--;
                }
                else // *
                {
                    leftMin--;
                    leftMax++;
                }

                if (leftMax < 0)
                    return false;

                /*
                 * About that part where we reset leftMin to 0 if it's negative.
                 * Take for example a string that looks like this  "(((***".
                 * After we have parsed this string our leftMax wil be 6 and our leftMin will be 0 which should return true because we can change every asterisk symbol for a right parenthesis symbol.
                 * But if we add another asterisk to that string "(((****" our leftMin will become -1.
                 * But in this case it doesn't make any sense for us to turn every asterisk into a right parenthesis because it will make the whole string invalid,
                 * that's why we treat one asterisk as an empty string and reset our leftMin to 0. And we don't afraid of a case like this "())" where we also should reset
                 * our leftMin because our leftMax will become less than 0 and it will return false
                 */
                if (leftMin < 0)
                    leftMin = 0;

            }

            return leftMin == 0;
        }
        
        

        
        
        static void Main(string[] args)
        {
            var q = CheckValidString("(*)");

            Console.ReadKey();
        }
    }
}