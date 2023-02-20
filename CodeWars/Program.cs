using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 1) return int.Parse(tokens.First());
            Stack<int> vals = new Stack<int>();
            int result = 0;
            for (int c = 0; c < tokens.Length; c++)
            {
                if (tokens[c] == "+" || tokens[c] == "-" || tokens[c] == "/" || tokens[c] == "*")
                {
                    var v1 = vals.Pop();
                    var v2 = vals.Pop();
                    result = calc(tokens[c], v1, v2);
                    vals.Push(result);
                }
                else
                {
                    vals.Push(int.Parse(tokens[c]));
                }
            }

            return result;
        }

        private static int calc(string i, int v1, int v2)
        {
            return i switch
            {
                "+" => v1 + v2,
                "-" => v2 - v1,
                "*" => v1 * v2,
                "/" => v2 / v1
            };
        }


        static void Main(string[] args)
        {
            var q = EvalRPN(new[] {"2", "1", "+", "3", "*"});
            Console.ReadKey();
        }
    }
}