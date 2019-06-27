using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapping_Rain_Water
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }
    }

    public class Solution
    {
        public int Trap(int[] heights)
        {
            int left = 0;
            int right = heights.Length - 1;

            int maxLeft = 0;
            int maxRight = 0;
            int waterFill = 0;
            while (left < right)
            {
                int l = heights[left];
                int r = heights[right];
                if(l<=r)
                {
                    if (l >= maxLeft) maxLeft = l;
                    else waterFill += maxLeft - l;
                    left++;
                }
                else
                {
                    if (r >= maxRight) maxRight = r;
                    else waterFill += maxRight - r;
                    right--;
                }


            }

            return waterFill;
        }
    }
}
