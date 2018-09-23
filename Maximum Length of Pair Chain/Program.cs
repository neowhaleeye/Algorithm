using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Length_of_Pair_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] paris = new int[3, 2] { { 1, 2 }, { 2, 3 }, { 3, 4 } };

            FindLongestChain(paris);

        }

        public static int FindLongestChain(int[,] pairs)
        {

            //Arrays.sort(pairs, (a, b)->a[0] - b[0]);
            //int N = pairs.length;
            //int[] dp = new int[N];
            //Arrays.fill(dp, 1);

            //for (int j = 1; j < N; ++j)
            //{
            //    for (int i = 0; i < j; ++i)
            //    {
            //        if (pairs[i][1] < pairs[j][0])
            //            dp[j] = Math.max(dp[j], dp[i] + 1);
            //    }
            ////}

            //int ans = 0;
            //for (int x: dp) if (x > ans) ans = x;
            //return ans;

            int rn = pairs.GetLength(0);
            int cn = pairs.GetLength(1);


            for (int i = 0; i < rn; i++)
            {
                //pairs[i,1]
                findNext(pairs, i, i + 1);
            }

            return 0;
        }

        static int count = 0;

        private static void findNext(int[,] pairs, int i, int nextI)
        {
            if(pairs[i, 1] < pairs[i + 1, 0])
            {
                count++;
                findNext(pairs, i + 1, i + 2);
            }
        }

    }
}
