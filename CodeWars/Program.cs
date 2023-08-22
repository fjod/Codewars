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
        private static Dictionary<Object, List<Object>> dict = new Dictionary<object, List<object>>();
        public class Solution
        {
            
            public bool IsPowerOfThree(int n) {
                if(n<=0)
                    return false;
                if(n==1)
                    return true;
                return n%3==0 && IsPowerOfThree(n/3);
            }

            private static Random rand = new Random();
            private static void CreateString()
            {

                string test = rand.Next().ToString();
                if (dict.TryGetValue(test, out var list))
                {
                    list.Add(test);
                }
                else
                {
                    dict.TryAdd(
                        test,
                        new List<Object>()
                        {
                            test
                        });
                }
            }
            
            private static void CreateInt()
            {
                int test = rand.Next();
                if (dict.TryGetValue(test, out var list))
                {
                    list.Add(test);
                }
                else
                {
                    dict.TryAdd(
                        test,
                        new List<Object>()
                        {
                            test
                        });
                }
            }

            static void Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                {
                    CreateString();
                    CreateInt();
                }

                dict.TryGetValue("zyc", out var ret);
            }
            
            private static void CheckOrder(IDictionary<Guid, ValueTuple<int,int>> dict, int max)
            {
                var sut = dict;
                List<Guid> order = new List<Guid>();
                for (int i = 0; i < max; i++) //add many
                {
                    var g = Guid.NewGuid();
                    sut.Add(g, new ValueTuple<int, int>(i, i*2));
                    order.Add(g);
                }

                var rand = new Random();
                for (int i = 0; i < max/100; i++) //delete 1%
                {
                    var v = rand.Next(0, max);
                    var index = order[v];
                    sut.Remove(index);
                }
        
                for (int i = 0; i < max/100; i++) // add new 1%
                {
                    var g = Guid.NewGuid();
                    sut.Add(g, new ValueTuple<int, int>(i, i*2));
                    order.Add(g);
                }
            }
        }

    }
}