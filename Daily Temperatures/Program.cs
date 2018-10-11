using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Temperatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] temp = new int[] {  41, 41, 77};

            var r = new Solution().DailyTemperatures(temp);

            r.ToList().ForEach(e => Console.WriteLine(e));
        }
    }

    public class Solution
    {
        public int[] DailyTemperatures(int[] T)
        {
            Stack<int[]> stack = new Stack<int[]>();
            int[] ret = new int[T.Length];
            for(int i=0;i<T.Length;i++)
            {
                int currentValue = T[i];
                while(stack.Count>0 && currentValue > stack.Peek()[1])
                {
                    int index = stack.Pop()[0];
                    ret[index] = i - index;
                }
                stack.Push(new int[] { i, T[i] });
            }

            return ret;


        }
    }
}
