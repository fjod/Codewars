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
        public static bool IsValid(string s)
        {
            if (s.Length == 1) return false;
            Stack<char> stack = new Stack<char>();
            foreach (var p in s)
            {
                if (p == '(' || p == '[' || p == '{') stack.Push(p);
                else
                {
                    if (stack.Count == 0) return false;
                    var prevChar = stack.Pop();
                    if (p == ')' && prevChar != '(') return false;
                    if (p == ']' && prevChar != '[') return false;
                    if (p == '}' && prevChar != '{') return false;
                }
            }

            return stack.Count == 0;
        }

        //chat GPT fix
        public static bool IsValid2(string s)
        {
            if (s.Length == 1) return false;
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (c == ')' && stack.Count > 0 && stack.Peek() == '(')
                    stack.Pop();
                else if (c == ']' && stack.Count > 0 && stack.Peek() == '[')
                    stack.Pop();
                else if (c == '}' && stack.Count > 0 && stack.Peek() == '{')
                    stack.Pop();
                else
                    return false;
            }
            return stack.Count == 0;
        }
        

        static void Main(string[] args)
        {
            var test = IsValid("){");
            Console.ReadKey();
        }
    }
}