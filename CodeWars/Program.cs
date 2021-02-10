using System;



namespace CodeWars
{
  

    class Program
    {
        
        static public int[] SortArrayByParity(int[] A)
        {
            int[] ret = new int[A.Length];
            int backCounter = 0;
            int forwardCounter = A.Length-1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    ret[backCounter] = A[i];
                    backCounter++;
                }
                else
                {
                    ret[forwardCounter] = A[i];
                    forwardCounter--;
                }
            }

            return ret;
        }
        static void Main(string[] args)
        {
            var e = SortArrayByParity(new[] {3, 1, 2, 4});
            Console.ReadKey();
        }
    }
}

