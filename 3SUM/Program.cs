using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            int[] a = new int[] { -1, 0, 1, 2, -1, -4 };

            new Solution().ThreeSum(a);
        }
    }

    class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            nums = nums.OrderBy(e => e).ToArray();
            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < nums.Length - 2; i++)
            {
                if(i==0 || (i>0 && nums[i] != nums[i-1]))
                {
                    int lo = i + 1;
                    int hi = nums.Length - 1;
                    while(lo<hi)
                    {
                        int sum = nums[i] + nums[lo] + nums[hi];
                        if(sum == 0)
                        {
                            List<int> combination = new List<int>();
                            combination.AddRange(new int[] { i,lo,hi });
                        }
                        else if (sum<
                    }
                }
            }

        }
    }

}
