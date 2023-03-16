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
        
        public static int[][] KClosest(int[][] points, int k)
        {
            var q = new PriorityQueue<int[], double>();
            foreach (var point in points)
            {
                var distance = Math.Sqrt(point[0] * point[0] + point[1] * point[1]);
                q.Enqueue(point, distance);
            }

            var ret = new int[k][];
            for (int i = 0; i < k; i++)
            {
                ret[i] = q.Dequeue();
            }

            return ret;
        }
        
        static void Main(string[] args)
        {
            var q = KClosest(new []{new[] {1,3}, new []{-2,2}}, 1);
            Console.ReadKey();
        }
    }
}