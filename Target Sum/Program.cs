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
            
            Dictionary<int, int>[] map = new Dictionary<int, int>[nums.Length];
            for(int i=0;i<nums.Length;i++)
            {
                map[i] = new Dictionary<int, int>();
            }

            return Find(nums, 0, S, map);


            //Helper(nums, 0, 0, S);
            //return count;
        }

        private int Find(int[] nums, int index, int target, Dictionary<int,int>[] map)
        {
            if (index == nums.Length) return (target == 0) ? 1 : 0;
            if (map[index].ContainsKey(target)) return map[index][target];

            int cnt = Find(nums, index + 1, target - nums[index], map)
                        + Find(nums, index + 1, target + nums[index], map);

            map[index][target] = cnt;
            return cnt;

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
