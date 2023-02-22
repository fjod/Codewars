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

        /// <summary>
        /// Time Limit Exceeded
        /// Last Executed Input
        /// 308 / 312 testcases passed
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> test = new List<int>();
                test.AddRange(nums);
                test.RemoveAt(i);
                List<(int,int)> remindersEqualToZero = Find(test, nums[i] * -1);
                foreach (var valueTuple in remindersEqualToZero)
                {
                    var list = new List<int>(3) {nums[i], valueTuple.Item1, valueTuple.Item2};
                    if (ret.All(l => GetHash(l) != GetHash(list)))
                    {
                        ret.Add(list);
                    }
                }
            }

            return ret;
        }

        private static int GetHash(IList<int> three)
        {
            return (three[0]*17).ToString().GetHashCode() + ((three[1]*17).ToString()).GetHashCode() + ((three[2]*17).ToString()).GetHashCode();
        }

        // find all pairs in test so pair1 + pair2 = num
        private static List<(int, int)> Find(List<int> test, int num)
        {
            List<(int, int)> ret = new List<(int, int)>();
            for (int i = 0; i < test.Count; i++)
            {
                var reminder = num - test[i];
                List<int> test2 = new List<int>();
                test2.AddRange(test);
                test2.RemoveAt(i);
                var reminders = test2.Where(v => v == reminder).Distinct();
                foreach (var reminder1 in reminders)
                {
                    if (!ret.Contains((test[i], reminder1))) ret.Add((test[i], reminder1));
                }
            }

            return ret;
        }


        static void Main(string[] args)
        {
            var q = ThreeSum(new[] {-1, 0, 1, 2, -1, -4});
            Console.ReadKey();
        }
    }
}