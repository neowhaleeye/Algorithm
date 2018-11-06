using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
         

            int[] nums = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4};
            Console.WriteLine(new Solution().MaxSubArray(nums));
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            return Sum(nums); ;
        }

       


        private int Sum(int[] nums)
        {
            int size = nums.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + nums[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;


            //if (index < 0) return;
            //if (index >= nums.Length) return;

          
            //for(int i=0;i<nums.Length;i++)
            //{
            //    int subSum = maximumNumber + nums[i];
            //    if (subSum < 0)
            //        subSum = 0;
            //    maximumNumber = Math.Max(subSum, maximumNumber);
            //}

         


            //s + nums.TakeWhile(i => (i >= si && i < ei));
            //maximumNumber = Math.Max(maximumNumber, subSum);

            //Sum(nums, index + 1, subSum);

        }
    }
}
