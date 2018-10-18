using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Size_Subarray_Sum_Equals_k
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -2, -1, 2, 1 };
            int k = 1;
            Console.WriteLine(new Solution().MaxSubArrayLen(nums, k));
        }
    }

    public class Solution
    {
       
        public int MaxSubArrayLen(int[] nums, int k)
        {
            int len = nums.Length;

            for(int i=1;i<len;i++)
            {
                nums[i] += nums[i - 1];
            }

            Dictionary<int, int> prevSum = new Dictionary<int, int>
            {
                { 0,-1 } // add this fake entry to make sum from 0 to j consistent
            };

            int max = 0;
            List<int> arrayLength = new List<int>();
            for (int i=0;i<len;i++)
            {
                int latterSum = nums[i] - k;
                if(prevSum.ContainsKey(latterSum))
                {
                    max = Math.Max(max, i - prevSum[latterSum]);
                }
                if (!prevSum.ContainsKey(nums[i]))
                {
                    prevSum.Add(nums[i], i);
                }
                
            }

            return max;
         
        }

       
    }
}
