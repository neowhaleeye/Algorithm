﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3 };
            var v = new Solution().Subsets(a);
        }
    }

    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            return helper(nums, new List<IList<int>>(), 0);
        }

        public IList<IList<int>> helper(int[] nums, IList<IList<int>> ans, int index)
        {

           

            if (index == 0) ans.Add(new List<int>());
            if (index == nums.Length) return ans;
            int precount = ans.Count;
            for (int i = 0; i < precount; i++)
            {
                IList<int> cur = new List<int>(ans[i]);
                cur.Add(nums[index]);
                ans.Add(cur);
            }
            return helper(nums, ans, index+1);
        }

    }
}
