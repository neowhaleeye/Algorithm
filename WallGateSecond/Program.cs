using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallGateSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            int[,] ag = new int[,] { { int.MaxValue, -1, 0, int.MaxValue }, { int.MaxValue, int.MaxValue, int.MaxValue, -1 }, { int.MaxValue, -1, int.MaxValue, -1 }, { 0, -1, int.MaxValue, int.MaxValue } };


            new Solution().WallsAndGates(ag);

            Console.WriteLine("AAAA");

            
            Console.ReadKey();
        }

        public class Solution
        {
            static readonly int EMPTY = Int32.MaxValue;
            static readonly int WALL = -1;
            static readonly int GATE = 0;
            static readonly List<int[]> DIRECTIONS = new List<int[]>
            {
                new int[] {1,0},
                new int[] {-1,0},
                new int[] {0,1},
                new int[] {0,-1},
            };



            public void WallsAndGates(int[,] rooms)
            {
                int rowCount = rooms.GetLength(0);
                int columnCount = rooms.GetLength(1);

                if (rowCount == 0 && columnCount == 0) return;

                Queue<int[]> q = new Queue<int[]>();
                for(int row=0;row<rowCount;row++)
                {
                    for(int col=0; col < columnCount; col++)
                    {
                        if(rooms[row,col] ==GATE)
                        {
                            q.Enqueue(new int[] { row, col });
                        }

                    }
                }

                while(q.Count>0)
                {
                    int[] point = q.Dequeue();
                    int row = point[0];
                    int col = point[1];
                    foreach(var dire in DIRECTIONS)
                    {
                        int r = row + dire[0];
                        int c = col + dire[1];
                        if (r < 0 || c < 0 || r >= rowCount || c >= columnCount || rooms[r, c] != EMPTY) continue;

                        rooms[r, c] = rooms[row, col] + 1;
                        q.Enqueue(new int[] { r, c });
                    }
                }

            }

            private void Search(int[,] rooms, int[] points, int rowCount, int columnCount)
            {
                Queue<int[]> pointQueue = new Queue<int[]>();
                int row = points[0];
                int column = points[1];
                pointQueue.Enqueue(new int[] { row, column });

                while (pointQueue.Count > 0)
                {
                    var current =  pointQueue.Dequeue();
                    row = current[0];
                    column = current[1];

                    int currentValue = rooms[row, column];

                    if (row > 0 && rooms[row - 1, column] == int.MaxValue)
                    {
                        rooms[row - 1, column] = currentValue + 1;
                        pointQueue.Enqueue(new int[] { row - 1, column });
                    }
                    if (row < rowCount - 1 && rooms[row + 1, column] == int.MaxValue)
                    {
                        rooms[row + 1, column] = currentValue + 1;
                        pointQueue.Enqueue(new int[] { row + 1, column });
                    }
                    if (column < columnCount - 1 && rooms[row, column + 1] == int.MaxValue)
                    {
                        rooms[row, column + 1] = currentValue + 1;
                        pointQueue.Enqueue(new int[] { row, column + 1 });

                    }
                    if (column > 0 && rooms[row, column-1] == int.MaxValue)
                    {
                        rooms[row, column - 1] = currentValue + 1;
                        pointQueue.Enqueue(new int[] { row, column - 1 });
                    }
                }
            }
        }
    }
}
