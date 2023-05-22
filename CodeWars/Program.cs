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
        public class Solution
        {
            public int CountPairs(int[] deliciousness)
            {
                int ret = backTrack(deliciousness.ToList());
                return ret;
            }

            //61 / 72 testcases passed
            private int backTrack(List<int> deliciousness)
            {
                HashSet<(int, int)> memo = new HashSet<(int, int)>();
                int total = 0;
                for (int i = 0; i < deliciousness.Count; i++)
                {
                    var current = deliciousness[i];
                    var copy = new List<int>(deliciousness);
                    copy.RemoveAt(i);
                    for (int j = 0; j < deliciousness.Count; j++)
                    {
                        if (i == j) continue;
                        var currentSum = current + deliciousness[j];
                        if ((currentSum != 0) && ((currentSum & (currentSum - 1)) == 0))
                        {
                            if (memo.Contains((i, j))) continue;
                            if (memo.Contains((j, i))) continue;
                            memo.Add((i, j));
                            total += 1;
                        }
                    }
                }

                return total;
            }

            private static long sumPrevious(int start)
            {
                // If we have a set of 1s...  lets say 3,
                // then the unique combinations will be
                // count(3) => 2 + 1 = 3
                // count(4) => 3 + 2 + 1 = 6
                long sum = 0;
                for (int cnt = 0; cnt < start; cnt++) sum += cnt;
                return sum;
            }

            public static int CountPairs2(int[] deliciousness)
            {
                // for each unique number, compare to self and all others
                long count = 0;

                // occurences of i-th number
                Dictionary<int, int> dict = new Dictionary<int, int>();
                foreach (var i in deliciousness)
                {
                    dict.TryAdd(i, 0);
                    dict[i]++;
                }

                HashSet<int> powersOfTwo = new HashSet<int>();
                for (int cnt = 0; cnt <= 21; cnt++)
                    powersOfTwo.Add((int) Math.Pow(2, cnt));

                // get unique numbers
                int[] uniqueNumbers = new List<int>(dict.Keys).ToArray();

                foreach (var input in uniqueNumbers)
                {
                    foreach (var pow in powersOfTwo)
                    {
                        int target = pow - input;
                        if (target == input)
                        {
                            count += sumPrevious(dict[input]);
                        }
                        else
                        {
                            if (dict.TryGetValue(target, out int amountOfCurrent)
                                && input < target) // to not count same pair second time
                            {
                                long temp = (long) amountOfCurrent * dict[input];
                                count += temp;
                            }
                        }
                    }
                }

                return (int) (count % 1000000007);
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                Console.WriteLine(CountPairs2(arr));
            }
        }
    }
}