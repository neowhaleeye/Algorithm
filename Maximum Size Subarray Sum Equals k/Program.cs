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
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int n = nums.Length;
            for (int i = 1; i < n; i++)
            {
                nums[i] += nums[i - 1];
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1); // add this fake entry to make sum from 0 to j consistent
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(nums[i] - k))
                    max = Math.Max(max, i - map[nums[i] - k]);
                if (!map.ContainsKey(nums[i])) // keep only 1st duplicate as we want first index as left as possible
                    map.Add(nums[i], i);
            }
            return max;

        }

       
    }
}
