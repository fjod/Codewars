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
            public bool IsPowerOfThree(int n) {
                if(n<=0)
                    return false;
                if(n==1)
                    return true;
                return n%3==0 && IsPowerOfThree(n/3);
            }

            static void Main(string[] args)
            {
                var sut = new Dictionary<Guid, ValueTuple<int,int>>();
                CheckOrder(sut, 100000);
                
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