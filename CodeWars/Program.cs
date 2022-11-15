using System;

namespace CodeWars
{
   
    class Program
    {
     // https://www.youtube.com/watch?v=g9YQyYi4IQQ   
        public static double MyPow(double x, int n)
        {
            if (x == 0) return 0;
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n == 2) return x * x;
            if (n > 0)
            {
                var div = n / 2; // 7/2 = 3
                double left = 1;
                if (n % 2 != 0) left = x;
                var calc = MyPow(x, div);
                return left * calc * calc;
            }
            else
            {
                var positiveN = n * -1;
                var div =positiveN / 2; // 7/2 = 3
                double left = 1;
                if (positiveN % 2 != 0) left = x;
                var calc = MyPow(x, div);
                var negRet =  1 / (left * calc * calc);
                if (double.IsInfinity(negRet))
                    return 0;
                return negRet;
            }

        }
        static void Main(string[] args)
        {
            var q = MyPow(2, -2);
        }
    }
}
