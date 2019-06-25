using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMZ_Test1
{
    class Program
    {
        const int a = 0;
        static void Main(string[] args)
        {
            int[,] area = new[,] { { 1, 1, 1, 1 }, { 0, 1, 1, 1 }, { 0, 1, 0, 1 }, { 1, 1, 9, 1 }, { 0,0,1,1} };
            //int[,] area = new[,] { { 1,1,1,1 }, { 0,0,1,1 }, {1,0,1,9 }};
            Console.WriteLine(new Amazon().minimumDistance(4, 4, area));
        }
    }

    class Amazon
    {
        List<int> results = new List<int>();
        public int minimumDistance(int numRows, int numColumns, int[,] area)
        {
            Traverse(area, 0, 0, numRows, numColumns, 0);

            return results.OrderBy(e => e).First();
        }

        private void Traverse(int[,] area, int r, int c, int numsRows, int numColumns, int counted)
        {
            if (r < 0 || r >= numsRows || c < 0 || c >= numColumns || area[r, c] == 0)
            {
                return;
            };

            if(area[r,c] == 9)
            {
                results.Add(counted);
                return;
            }
            else
            {
                counted++;
                area[r, c] = 0;
                Traverse(area, r - 1, c, numsRows, numColumns, counted);
                Traverse(area, r + 1, c, numsRows, numColumns, counted);
                Traverse(area, r, c - 1, numsRows, numColumns, counted);
                Traverse(area, r, c + 1, numsRows, numColumns, counted);
            }
        }
    }
}
