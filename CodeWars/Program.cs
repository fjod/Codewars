using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public IList<IList<int>> Combine(int n, int k)
        {
            var output = new List<IList<int>>();
            Generate(output, new List<int>(), n, k, 1);
            return output;
        }

        public void Generate(IList<IList<int>> output, List<int> current, int n, int k, int start)
        {
            if (current.Count == k)
            {
                var temp = new List<int>();
                temp.AddRange(current);
                output.Add(temp);
                return;
            }

            for (int i = start; i <= n; i++)
            {
                current.Add(i);
                Generate(output, current, n, k, i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}