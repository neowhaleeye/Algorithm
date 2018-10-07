using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] area = new[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 9, 1 } };
            int[,] area = new[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 1, 9, 1 } };
            minimumDistance(3, 3, area);
        }

        public static int minimumDistance(int numRows, int numColumns, int[,] area)
        {

            int numberOfRoute = 0;
            int nr = numRows;

            int nc = numColumns;
            Dfs(area, 0, 0, 0);
           

            //Console.WriteLine(a);
            Console.WriteLine(final);
            return numberOfRoute;
        }

        //private static int a;
        private static int final;

        private static void Dfs(int[,] grid, int r, int c, int routePast)
        {
            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);
            

            
            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r, c] == 0)
            {
                return;
            }

            if(grid[r, c] == 9)
            {
                final = routePast;
                return;
            }

            if (grid[r, c] == 1)
                routePast++;


            grid[r, c] = 0;
            Dfs(grid, r - 1, c, routePast);
            Dfs(grid, r + 1, c, routePast);
            Dfs(grid, r, c + 1, routePast);
            Dfs(grid, r, c - 1, routePast);
        }
    }
}
