using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSiztSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            int[] nums = new int[] { 1, 2, -3, 3, -1, 2, 4 };

            Console.WriteLine(new Solution().maxSubArrayLen(nums, 3));
        }
    }

    class Solution
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        
        public int maxSubArrayLen(int[] nums, int k)
        {
            int sum = 0, result = 0;
            Dictionary<int, int> preSum = new Dictionary<int,int>();
            preSum.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (preSum.ContainsKey(sum - k))
                {
                    result += preSum[sum - k];
                }

                int val = preSum.ContainsKey(sum) ? preSum[sum] : 0;
                preSum.Add(sum, val + 1);
            }

            return result;

        }
    }
}
