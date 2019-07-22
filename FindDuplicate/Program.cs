using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));

            //repeatedNumber(new List<int>() { 1, 3, 4, 2, 2 });

            int[] list = new int[] { 1, 2, 3, 1 };
            //Console.WriteLine(Naive(list));

            Console.WriteLine(Naive2(list, 3));


        }

        private static bool Naive2(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = Math.Max(i-k,0); j < i; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }

            }
            return false;


            
        }

        private static bool Naive(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }

            }
            return false;
        }

        public static int FindDuplicate(int[] nums)
        {
            int sum = 0;
            int indexSum = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                indexSum += i;
            }
            
            for (int i = 0; i < nums.Length; i++)
            {
                
                sum = sum + nums[i];
            }

            return sum - indexSum;
        }

        public static int repeatedNumber(List<int> list)
        {
            if (list.Count <= 1)
                return -1;

            int slow = list[0];                ;
            int fast = list[list[0]];

            Console.WriteLine(fast);
            while (fast != slow)
            {
                slow = list[slow];
                Console.WriteLine(fast);
                fast = list[list[fast]];
            }

            slow = 0;
            while (fast != slow)
            {
                slow = list[slow];
                fast = list[fast];
            }
            return slow;
        }

    }
}
