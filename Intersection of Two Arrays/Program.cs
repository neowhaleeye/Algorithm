using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection_of_Two_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 2, 1 };
            int[] arr2 = new int[] { 2,2};

            new Solution().Intersect(arr,arr2);
        }
    }

    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (map.ContainsKey(nums1[i])) map[nums1[i]] += 1;
                else map.Add(nums1[i], 1);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (map.ContainsKey(nums2[i]) && map[nums2[i]] > 0)
                {
                    result.Add(nums2[i]);

                    map[nums2[i]] -= 1;
                    //map.Add(nums2[i], map[nums2[i]] -1);
                }
            }

            int[] r = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                r[i] = result[i];
            }

            return r;


        }
    }
}
