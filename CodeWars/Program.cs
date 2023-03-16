using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public int[][] Insert(int[][] intervals, int[] newInterval) {
            var result = new List<int[]>();

            for (var i = 0; i < intervals.Length; i++)
            {
                var targetEnd = newInterval[1];
                var targetStart = newInterval[0];
                var currentStart = intervals[i][0];
                var currentEnd = intervals[i][1];
                // новый интервал перед текущим интервалом
                if (targetEnd < currentStart)
                {
                    result.Add(newInterval);
                    result.AddRange(intervals.AsEnumerable().Skip(i).ToArray());
                    return result.ToArray();
                }

                // новый интервал после текущего интервала
                if (targetStart > currentEnd)
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    // новый интервал частично внутри текущего интервала, пересчитаем границы нового
                    newInterval[0] = Math.Min(currentStart, targetStart);
                    newInterval[1] = Math.Max(currentEnd, targetEnd);
                }
            }

            // если новый интервал был сразу позади всех
            result.Add(newInterval);

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            var q = Insert(new[] {new[] {1, 2}, new[] {3, 5}, new []{6,7}, new []{8,10}, new []{12,16}}, new[] {4, 8});
            Console.ReadKey();
        }
    }
}