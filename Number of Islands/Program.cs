using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_of_Islands
{
    public class Solution
    {

        public int NumIslands(char[][] grid)
        {

            int numberOfIsland = 0;
            int nr = grid.Length;
            for (int r = 0; r < nr; r++)
            {
                int nc = grid[r].Length;
                for (int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numberOfIsland++;
                        Traverse(grid, r, c, nr, nc);
                    }

                }
            }

            return numberOfIsland;
        }

        private void Traverse(char[][] grid, int row, int column, int totalRow, int totalColumn)
        {

            if (row < 0 || column < 0 || row >= totalRow || column >= totalColumn || grid[row][column] == '0')
                return;

            grid[row][column] = '0';

            Traverse(grid, row + 1, column, totalRow, totalColumn);
            Traverse(grid, row - 1, column, totalRow, totalColumn);
            Traverse(grid, row, column + 1, totalRow, totalColumn);
            Traverse(grid, row, column - 1, totalRow, totalColumn);


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char[][] grid = new char[4][];
            grid[0] = new char[] { '1','1','1','1','0' };
            grid[1] = new char[] { '1', '1', '0', '1', '0' };
            grid[2] = new char[] { '1', '1', '0', '0', '0' };
            grid[3] = new char[] { '0', '0', '0', '0', '0' };
          
            Console.WriteLine(new Solution().NumIslands(grid)); 

        }

        public static int NumIslands(char[,] grid)
        {
            int numberOfIsland = 0;
            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);
            for (int r = 0; r < nr; r++)
            {
                for (int c = 0; c < nc; c++)
                {
                    if (grid[r, c] == '1')
                    {
                        numberOfIsland++;
                        Dfs(grid, r, c);
                    }

                }
            }

            return numberOfIsland;
        }

        private static void Search(char[,] grid, int r, int c)
        {
            int tr = grid.GetLength(0);
            int tc = grid.GetLength(1);

            if (r < 0 || c >= tc || r >= tr || c < 0 || grid[r, c] == '0') return;

            grid[r, c] = '0';
            Search(grid, r + 1, c);
            Search(grid, r - 1, c);
            Search(grid, r , c+1);
            Search(grid, r , c-1);
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
