using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSets
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Solution
    {
        public List<List<int>> subsets(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();

            result.Add(new List<int>());

            foreach(int n in nums)
            {
                int size = result.Count;
                for(int i=0;i<size;i++)
                {
                    List<int> subset = new List<int>(result[i]);
                    subset.Add(n);
                    result.Add(subset);
                }

            }

            return result;
            
            


            //List<List<int>> result = new List<List<int>>();
            //result.Add(new List<int>());
            //foreach (int n in nums)
            //{
            //    int size = result.Count;
            //    for (int i = 0; i < size; i++)
            //    {
            //        List<int> subset = new List<int>(result[i]);
            //        subset.Add(n);
            //        result.Add(subset);
            //    }
            //}
            //return result;
        }

       
    }
}
