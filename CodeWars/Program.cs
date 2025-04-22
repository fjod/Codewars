using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace CodeWars
{
    /* 
        | Method             | Mean      | Error    | StdDev   | Allocated |
        |------------------- |----------:|---------:|---------:|----------:|
        | MajorityArraySort  |  65.18 us | 1.260 us | 1.808 us |         - |
        | MajorityDictionary | 164.88 us | 2.510 us | 1.960 us |     424 B |
        */
    public class Majority
    {
        private static IEnumerable<int> Generate()
        {
            for (int i = 0; i < 15000; i++)
            {
                yield return 1;
            }

            for (int i = 2; i < 5; i++)
            {
                for (int k = 0; k < 2000; k++)
                {
                    yield return i;
                }
            }
        }

        private readonly int[] _nums = Generate().ToArray();
        
        [Benchmark]
        public int MajorityArraySort() {
            Array.Sort(_nums);
            return _nums[_nums.Length / 2];
        }
        
        [Benchmark]
        public int MajorityDictionary() {
        
            // can work without the array
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int counter = 0;
            foreach (var num in Generate())
            {
                if (!dict.TryAdd(num, 1))
                {
                    dict[num]++;
                }

                counter++;
            }

            foreach (var num in dict)
            {
                if (num.Value > counter / 2)
                {
                    return num.Key;
                }
            }

            throw new Exception();
        }
    }
    
    class Program
    {
       
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Majority>();
        }
    }
}