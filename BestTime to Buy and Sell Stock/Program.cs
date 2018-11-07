using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTime_to_Buy_and_Sell_Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] price = new[] { 7, 1, 5, 3, 6, 4};
            Console.WriteLine(new Solution().maxProfit(price));
        }
    }

    public class Solution
    {
        public int maxProfit(int[] prices)
        {
            int mininumPrice = int.MaxValue;
            int maxProfit = 0;
            foreach(int p in prices)
            {
                if (p < mininumPrice)
                    mininumPrice = p;

                int profit = p - mininumPrice;
                if (profit > 0 && maxProfit < profit)
                    maxProfit = profit;
            }

            return maxProfit;
        }
    }
}