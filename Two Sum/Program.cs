using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbs = new int[] { 3,2,4};
            var result = TwoSum(numbs, 6);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            for(int i=0;i<nums.Length;i++)
            {
                int element = nums[i];
                int diff = target - element;

                if(hash.ContainsKey(diff) )
                {
                    return new int[2] { i, Convert.ToInt32(hash[diff]) };
                }

                hash.Add(element, i);

            }

            throw new InvalidProgramException();




        }
    }
}
