using System;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static int FindNumbers(int[] nums) => nums.Count(evenNumOfDigits);
    
        static bool evenNumOfDigits(int n) {
            int count = 0;
            while(0 < n) {
                n /= 10;
                ++count;
            }
            return count % 2 == 0;
        }
        static void Main(string[] args)
        {
            var i = FindNumbers(new[] {12,345,2,6,7896});
            Console.ReadKey();
        }
    }
}

