using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicateUsingHash
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1,-2,-4,0};
            new Solution().ContainsDuplicate(nums);
        }
    }

    public class Solution
    {

        private bool[] hasedArray;

        public bool ContainsDuplicate(int[] nums)
        {
            
            Rebase(nums, nums.Min(e=>e));
            return false;
            //if (nums.Length == 0) return false;
            //hasedArray = new bool[nums.Max(e=>Math.Abs(e))*2+1];

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int key = Hash(nums[i], hasedArray.Length);
                
            //    if (!hasedArray[key])
            //        hasedArray[key] = true;
            //    else
            //        return true;
            //}

            //return false;


        }

        private void Rebase(int[] nums, int minValue)
        {
            for(int i=0;i<nums.Length;i++)
            {
                nums[i] = nums[i] - minValue;
            }
        }

        private int Hash(int num, int totalArray)
        {
            int potentialKey = num % totalArray;
            int middleIndex = totalArray / 2;
            if (num == 0) return middleIndex;
            if (potentialKey > 0)
                return num % totalArray + middleIndex;
            else
                return middleIndex - potentialKey * -1;




        }
    }
}
