namespace CodeWars
{
   
    class Program
    {
        static bool IsBadVersion(int i)
        {
            return i == 4;
        }
        
        public static int FirstBadVersion(int n)
        {
            if (n == 0) return 0;
            if (n == 1)
            {
                if (IsBadVersion(1)) return 1;
                return 0;
            };

            int left = 0;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                var isCurrentBad = IsBadVersion(mid);
                var isNextBad = IsBadVersion(mid + 1);

                if (isCurrentBad == false && isNextBad == false)
                {
                    left = mid;
                    continue;
                }
                if (isCurrentBad == true && isNextBad == true)
                {
                    right = mid;
                    continue;
                }
                
                if (isCurrentBad == false && isNextBad == true)
                {
                    return mid+1;
                }
            }

            if (IsBadVersion(left) && !IsBadVersion(right))
            {
                return left;
            }

            return 0;
        }
        
        static void Main(string[] args)
        {
            var q = FirstBadVersion(5);
        }
    }
}
