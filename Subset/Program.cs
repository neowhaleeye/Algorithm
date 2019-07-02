using System;
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
            var v = new Solution().subsets(a);
        }
    }

    public class Solution
    {
        public List<List<int>> subsets(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            backtrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int start)
        {
            list.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                backtrack(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }


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
