using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWars
{
  

    class Program
    {
        
        public static bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length <= 1) return false;
            var q = deck.GroupBy(i => i);
            if (q.Count() == 1) return true;
            int? minCount = null;
            foreach (var group in q)
            {
                var currentCount = group.Count();
                if (minCount.HasValue)
                {
                    if (currentCount < minCount)
                    {
                        //found new minimalCount
                        minCount = currentCount;
                    }
                    
                }
                else
                    minCount = currentCount;
            }

            if (minCount == 1) return false;

            int GCD(int a, int b)
            {
                return b == 0 ? a : GCD(b, a % b);
            }

            
            List<int> gdcs = new List<int>();
            foreach (var group in q)
            {
                var currentCount = group.Count();
                if (currentCount % minCount != 0)
                {
                    int bigCount = Math.Max(currentCount, minCount.Value);
                    int smallCount = Math.Min(currentCount, minCount.Value);
                    var gcd = GCD(bigCount, smallCount);
                    if (gcd > 1)
                        gdcs.Add(gcd);
                }
                else
                {
                    gdcs.Add(minCount.Value);
                }
                
            }
            //code fails for [1,1,1,1,2,2,2,2,2,2]
            if (gdcs.Count() < 2) return false;
           
                var first = gdcs.First();
                var allTheSame = gdcs.All(i => i == first);
                return allTheSame;
            
       
        }
        static void Main(string[] args)
        {
            var q = HasGroupsSizeX(new[] {1,1,1,1,2,2,2,2,2,2});
            Console.ReadKey();
        }
    }
}

//914. X of a Kind in a Deck of Cards
//it's too hard :(
//  return deck.GroupBy(e => e).Select(I => I.Count()).Aggregate(GCD) >= 2;
//I did not manage to think of to Aggregate func; but was on right track
