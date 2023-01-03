using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        class Node
        {
            public char Value { get; init; }
            public int NumOfOpen { get; init; }

            public List<Node> Children { get; } = new List<Node>();
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            var start = new Node {Value = '0', NumOfOpen = 0};
            BuildTree(start, 0, n);
            List<string> ret = new List<string>();
            StringBuilder sb = new StringBuilder();
            PrintTree(start, ret, sb);
            return ret;
        }

        static void BuildTree(Node start, int current, int max)
        {
            if (current + 1 <= max)
            {
                var open = new Node {Value = '(', NumOfOpen = start.NumOfOpen + 1};
                start.Children.Add(open);
                BuildTree(open, current + 1, max);
            }

            if (start.NumOfOpen > 0)
            {
                var closed = new Node {Value = ')', NumOfOpen = start.NumOfOpen - 1};
                start.Children.Add(closed);
                BuildTree(closed, current, max);
            }
        }

        static void PrintTree(Node start, List<string> ret, StringBuilder sb)
        {
            if (start.Value != '0') sb.Append(start.Value);
            if (start.Children.Count == 0)
            {
                ret.Add(sb.ToString());
            }

            foreach (var node in start.Children)
            {
                PrintTree(node, ret, sb);
            }

            if (start.Value != '0') sb.Remove(sb.Length - 1, 1);
        }

        static void Main(string[] args)
        {
            var q = GenerateParenthesis(2);
        }
    }
}