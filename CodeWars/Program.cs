using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        
        public static IList<string> GenerateParenthesis(int n) {
            List<String> solutions = new List<string>();
            addParenthesis(new char[n * 2], 0, n, n, solutions);
            return solutions;
        }

        private static void addParenthesis(char[] currentExpr, int index, int leftRemain, int rightRemain, List<String> solutions) {
            if (leftRemain == 0 && rightRemain == 0) {
                solutions.Add(new String(currentExpr));
                return;
            }
            if (leftRemain > 0) {
                currentExpr[index] = '(';
                addParenthesis(currentExpr, index + 1, leftRemain - 1, rightRemain, solutions);
            }
            if (rightRemain > 0 && rightRemain > leftRemain) {
                currentExpr[index] = ')';
                addParenthesis(currentExpr, index + 1, leftRemain, rightRemain - 1, solutions);
            }
        }
    
        static void Main(string[] args)
        {
            GenerateParenthesis(3);
            Console.ReadKey();
        }
    }
}