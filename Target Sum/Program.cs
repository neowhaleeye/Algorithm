using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1,1,1,1,1};
            int s = 3;

            Console.WriteLine(new Solution().FindTargetSumWays(nums, s));
        }
    }

    public class Solution
    {
        int count = 0;
        public int FindTargetSumWays(int[] nums, int S)
        {
            Helper(nums, 0, 0, S);
            return count;
        }

        private void Helper(int[] nums, int index, int sum, int s)
        {
            if(index == nums.Length)
            {
                if(sum == s)
                {
                    count++;
                }
                return;
            }
            Helper(nums, index + 1, sum + nums[index], s);
            Helper(nums, index + 1, sum - nums[index], s);

        }
    }
}
