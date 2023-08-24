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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = IsGood(new[] {1, 3, 3, 2});
            Console.Write(1);
        }
        
        public static bool IsGood(int[] nums)
        {
            var ordered = nums.OrderBy(n => n).GetEnumerator();
            var max = nums.Max();
            var en = Create(Enumerable.Range(1, max), max);
            var z = en.GetEnumerator();
            
            ordered.MoveNext();
            z.MoveNext();
            for (int i = 0; i < nums.Length; i++)
            {
                var fromOrdered = ordered.Current;
                var fromPattern = z.Current;
                if (fromOrdered != fromPattern) return false;
                var okOrdered = ordered.MoveNext();
                var okPatter = z.MoveNext();
                if (!okOrdered && !okPatter) return true;
                if (!(okOrdered && okPatter))
                    return false;
            }

            return true;
        }

        static IEnumerable<int> Create(IEnumerable<int> input, int max)
        {
            foreach (var VARIABLE in input)
            {
                yield return VARIABLE;
            }

            yield return max;
        }
    }
}