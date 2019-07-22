using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { -1, 0, 1, 2, -1, -4 };
            new Solution().ThreeSum(arr);
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ordered = nums.OrderBy(e => e).ToList();

            
            HashSet<List<int>> result = new HashSet<List<int>>();

            for (int i = 0; i < ordered.Count() - 2; i++)
            {
                int first = i;
                int second = i + 1;
                int third = nums.Length - 1;

                while(second<third)
                {
                    int firstValue = ordered[first];
                    int secondValue = ordered[second];
                    int thirdValue = ordered[third];

                    int sumofThree = firstValue + secondValue + thirdValue;
                    if (sumofThree == 0)
                    {
                        List<int> matched = new List<int>();
                        matched.Add(firstValue);
                        matched.Add(secondValue);
                        matched.Add(thirdValue);
                        result.Add(matched);
                        second++;
                        third--;
                    }
                    else if(sumofThree<0)
                    {
                        second++;
                    }
                    else
                    {
                        third--;
                    }
                }


            }


            IList<IList<int>> r = new List<IList<int>>();
            result.ToList().ForEach(e => r.Add(e));

            return r;


        }
    }
}
