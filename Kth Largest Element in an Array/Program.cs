using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_Largest_Element_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] param = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            Console.WriteLine(findKthLargest(param, 4));
        }

        public static int FindKthLargest(int[] nums, int k)
        {


            var result = nums.OrderByDescending(e => e).Select((e, i) => new { Value = e, Index = i });

            return result.Skip(3).FirstOrDefault().Value;

            //var selected = result.Where(e => e.Index+1 == k).FirstOrDefault();

            //if (selected != null)
            //    return selected.Value;

            //throw new Exception("Invalid Assumption");

        }

        private static int FindUsingQueue(int[] nums, int k)
        {
            //https://hackernoon.com/what-does-the-time-complexity-o-log-n-actually-mean-45f94bb5bfbf?gi=95889b7c481e
            return 0;
            //SortedList<int, int> list = new SortedList<int, int>();


        }



        private static int findKthLargest(int[] nums, int k)
        {
            k = nums.Length - k;
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int j = partition(nums, lo, hi);
                if (j < k)
                {
                    lo = j + 1;
                }
                else if (j > k)
                {
                    hi = j - 1;
                }
                else break;
            }
            return nums[k];
        }

        private static int partition(int[] a, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (i < hi && less(a[++i], a[lo])) ;
                while (j > lo && less(a[lo] , a[--j])) ;
                if (i >= j) break;
                exchange(a, i, j);
            }
            exchange(a, lo, j);
            return j;
        }

        private static bool less (int a, int b)
        {
            return a < b;
        }

        private static void exchange(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
