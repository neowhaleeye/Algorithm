using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_of_Islands
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[4, 5];
            grid[0,0] = '1';
            grid[0,1] = '1';
            grid[0,2] = '0';
            grid[0,3] = '0';
            grid[0,4] = '0';

            grid[1,0] = '1';
            grid[1,1] = '1';
            grid[1,2] = '0';
            grid[1,3] = '0';
            grid[1,4] = '0';

            grid[2,0] = '0';
            grid[2,1] = '0';
            grid[2,2] = '1';
            grid[2,3] = '0';
            grid[2,4] = '0';

            grid[3,0] = '0';
            grid[3,1] = '0';
            grid[3,2] = '0';
            grid[3,3] = '1';
            grid[3,4] = '1';
            Console.WriteLine(NumIslands(grid)); 

        }
      
        public static int NumIslands(char[,] grid)
        {
            int numberOfIsland = 0;
            int nr = grid.GetLength(0);

            int nc = grid.GetLength(1);
            for (int r=0;r<nr;r++)
            {
                for(int c=0;c<nc;c++)
                {
                    if(grid[r,c]== '1')
                    {
                        numberOfIsland++;
                        Dfs(grid, r, c);
                    }

                }
            }

            return numberOfIsland;
        }

        private static void Dfs(char[,] grid, int r, int c)
        {
            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);

            if(r < 0 || c<0 || r>=nr || c>=nc || grid[r,c] == '0')
            {
                return;
            }

            grid[r,c] = '0';
            Dfs(grid, r - 1, c);
            Dfs(grid, r + 1, c);
            Dfs(grid, r, c+1);
            Dfs(grid, r, c - 1);
        }
    }
}
