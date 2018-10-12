using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().NumSquares(12));
        }
    }

    public class Solution
    {
        public int NumSquares(int n)
        {
            int num = Convert.ToInt32(Math.Floor((Math.Sqrt(n))));

            Stack<int> list = new Stack<int>();
            list.Push(num);
            while (list.Count > 0)
            {
                int current = list.Peek();
                int remain = n - list.Sum(e=>e*e);
                if (remain == 0) break;
                if(Math.Floor(Math.Sqrt(remain))<2)
                {
                    int down = list.Pop() - 1;
                    list.Push(down);
                }
                else
                {
                    list.Push(Convert.ToInt32(Math.Floor((Math.Sqrt(remain)))));
                }
            }

            return list.Count;

            
        }
    }
}
