using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_Largest_Element_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] param = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            FindKthLargest(param, 4);
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            var result = nums.OrderByDescending(e => e).Select((e, i) => new { Value = e, Index = i });
            var selected = result.Where(e => e.Index+1 == k).FirstOrDefault();

            if (selected != null)
                return selected.Value;

            throw new Exception("Invalid Assumption");

        }
    }
}
