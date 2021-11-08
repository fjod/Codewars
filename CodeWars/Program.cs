using System;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static int maxNumber(int[] nums)
        {
            return nums.OrderBy(i => i).Count(i => i is > 9 and < 100 or > 999 and < 10000 or > 99999 and < 1000000);
        }
        static void Main(string[] args)
        {
            var i = maxNumber(new[] {12,345,2,6,7896});
            Console.ReadKey();
        }
    }
}

