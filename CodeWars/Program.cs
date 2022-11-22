using System;

namespace CodeWars
{
   
    class Program
    {
        public static bool IsPerfectSquare(int num)
        {

            if (num == 1) return true;
            
            int left = 1;
            int right = num / 2;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                long dMid = (long)mid * (long)mid;
                if ((int)dMid == num) return true;
                if (dMid > num || dMid < 0)
                {
                    var temp = right;
                    right = right - (right - mid) / 2;
                    if (right == temp) right -= 1;
                }
                else
                {
                    var temp = left;
                    left = left + (mid - left) / 2;
                    if (left == temp) left += 1;
                   
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            var q = IsPerfectSquare(2147395600);
        }
    }
}
