using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().SingleNumber(new int[] { 1,4,1,4,5});
        }
    }

    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            HashSet<int> diffCont = new HashSet<int>();
            
            
            int result = 0;
            foreach (int num in nums)
                result ^= num;
            return result;
        }
    }
}
