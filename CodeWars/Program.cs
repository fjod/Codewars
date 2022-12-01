using System;
using System.Collections.Generic;
using System.IO.Enumeration;

namespace CodeWars
{
    
    
    class Program
    {
        public static int FindCircleNum(int[][] isConnected) {
        
            var set = new DisjointSet(isConnected.Length);
            for (int i = 0; i < isConnected.Length; i++)
            {
                for (int j = 0; j < isConnected[i].Length; j++)
                {
                    var rowValue = isConnected[i][j];
                    if (rowValue == 1 && i != j)
                    {
                        set.union(i, j);
                    }
                }
            }

            List<int> count = new List<int>();
            for (int i = 0; i < isConnected.Length; i++)
            {
                var current = set.GetArrayValue(i);
                if (!count.Contains(current))
                    count.Add(current);
            }

            return count.Count;
        }
        
        static void Main(string[] args)
        {
            var set = new DisjointSet(10);
            set.union(0, 1);
            set.union(2, 0);
            set.union(3, 1);
            set.union(4, 8);
            set.union(5, 7);
            set.union(5, 6);
            var q = set.findRoot(0);
            q = set.findRoot(1);
            q = set.findRoot(2);
            q = set.findRoot(3);

        }
    }
}
