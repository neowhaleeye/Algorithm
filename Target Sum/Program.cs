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
            int[] nums = new int[] {1,1,1,1,1};
            int s = 3;

            Console.WriteLine(new Solution().Myway(nums, s));
            //Console.WriteLine(new Solution().FindTargetSumWays(nums, s));
        }
    }

    public class Memo
    {
        Dictionary<int, List<int>> memo = null;
        public Memo(int capacity)
        {
             memo = new Dictionary<int, List<int>>();
            for (int i = 0; i < capacity; i++)
            {
                memo.Add(i, new List<int>());
            }
        }

        public void Add(int index, int value)
        {
            if(!memo.ContainsKey(index))
            {
                memo.Add(index, new List<int>() { value });
            }
            else
            {
                    memo[index].Add(value);
            }
        }

        public bool HaveValue(int index)
        {
            return memo.ContainsKey(index);
        }

        public List<int> Get(int index)
        {
            return memo[index];
        }

    }

    public class Solution
    {
        public int Myway(int[] nums, int s)
        {
            Memo m = new Memo(nums.Length);

          
            for(int i=0;i<nums.Length;i++)
            {
                Recursive(nums, i, 0,  m);
            }

            int cnt = m.Get(nums.Length - 1).Where(e => e == s).Count();
            return cnt;


        }

        private void Recursive(int[] nums, int index,  int s, Memo m)
        {  
            if (index == 0)
            {
                m.Add(index, nums[index]);
                m.Add(index, nums[index]*-1);
            }
            else
            {
                foreach (int i in m.Get(index - 1))
                {
                    m.Add(index, i + nums[index]);
                    m.Add(index, i + nums[index]*-1);
                }
            }
            
        }

       
        


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
