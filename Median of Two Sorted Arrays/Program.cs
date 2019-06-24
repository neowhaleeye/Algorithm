using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hs = new List<int>();

            int[] nums1 = new int[] { 1,1};
            int[] nums2 = new int[] { 1,2};

            foreach (int n in nums1)
            {
                hs.Add(n);
            }
            foreach (int n in nums2)
            {
                hs.Add(n);
            }

            int median = hs.Count / 2;
            int r = hs.Count % 2;

            int startPnt = median, endPnt = median;
            IEnumerable<int> result = null;
            double sum = 0;
            if (r == 0)
            {
                startPnt = median - 1;
                result = hs.OrderBy(e => e).Skip(startPnt).Take(2);
                sum = Convert.ToDouble(result.Sum()) / 2;
            }
            else
            {
                result = hs.OrderBy(e => e).Skip(startPnt).Take(1);
                sum = result.Sum();
            }


            

        }
    }
}
