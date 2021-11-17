using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //I was not able to solve it myself
            
            // Set p1 and p2 to point to the end of their respective arrays.
            int p1 = m - 1; //bigger array
            int p2 = n - 1; //smaller array

            // p is pointing on the end of big array
            // And move p backwards through the array, each time writing
            // the smallest value pointed at by p1 or p2.
            for (int p = m + n - 1; p >= 0; p--)
            {
                if (p2 < 0) //points into smaller array which is to merge inside bigger
                {
                    break;
                }

                //if big pointer is ok and nums2 number is smaller, than write nums1 value and shift p1
                if (p1 >= 0 && nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1--];
                }
                else
                {
                    nums1[p] = nums2[p2--]; //nums2 is bigger - wrote nums2 and shift p2
                }
            }
        }

        static void Main(string[] args)
        {
            int[] empty = new int[0];
            var nums1 = new[] {1, 2, 3, 0, 0, 0};
            Merge(nums1,3,new[] {2,5,6},3); //[1,2,2,3,5,6]
            
            nums1 = new[] {1};
            Merge(nums1,1,empty,0);
            
            nums1 = new[] {0};
            Merge(nums1,0,new[] {1},1);
            
            nums1 = new[] {2,0};
            Merge(nums1,1,new[] {1},1);
            nums1 = new[] {4,5,6,0,0,0};
            Merge(nums1,3,new[] {1,2,3},3);
            nums1 = new[] {1,2,4,5,6,0};
            Merge(nums1,6,new[] {3},1);
            
            nums1 = new[] {1,2,3,0,0,0};
            Merge(nums1,3,new[] {2,5,6},3);
            
            nums1 = new[] {1,0};
            Merge(nums1,1,new[] {2},1);
            
            nums1 = new[] {-1, 0, 0, 3, 3, 3, 0, 0, 0};
            Merge(nums1,6,new[] {1,2,2},3);
            Console.ReadKey();
        }
    }
}

