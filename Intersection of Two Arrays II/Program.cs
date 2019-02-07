using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection_of_Two_Arrays_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            int[] a = new int[3]{ 4,9,5};
            int[] b = new int[5] { 4, 9, 4,8,4 };

            new Solution().Intersect(a, b);
        }
    }

    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach(int n in nums1)
            {
                if (!hash.ContainsKey(n)) hash.Add(n, 1);
                else hash[n]++;
            }
            foreach(int n in nums2)
            {
                if (hash.ContainsKey(n) && hash[n] > 0)
                {
                    result.Add(n);
                    hash[n]--;
                }
            }

            return result.ToArray();
        }
    }
}
