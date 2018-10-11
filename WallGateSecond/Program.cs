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
            public void WallsAndGates(int[,] rooms)
            {
                int rowCount = rooms.GetLength(0);
                int columnCount = rooms.GetLength(1);

                if (rowCount == 0 && columnCount == 0) return;

                List<int[,]> result = new List<int[,]>();
             

                for (int i=0; i<rowCount;i++)
                {
                    for (int j=0;j<columnCount;j++)
                    {
                        if(rooms[i,j] == 0)
                        {
                            result.Add((int[,])rooms.Clone());
                            Search(result.Last(), new int[] { i, j }, rowCount, columnCount);
                        }
                    }
                }

                if (result.Count>0)
                {
                    int[,]  finalResult = result[0];
                    foreach (var current in result)
                    {
                        for (int k = 0; k < rowCount; k++)
                        {
                            for (int m = 0; m < columnCount; m++)
                            {
                                finalResult[k, m] = Math.Min(finalResult[k, m], current[k, m]);
                            }
                        }
                    }

                    for (int k = 0; k < rowCount; k++)
                    {
                        for (int m = 0; m < columnCount; m++)
                        {
                            rooms[k, m] = finalResult[k, m];
                        }
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
                        rooms[row - 1, column] = Math.Min(rooms[row - 1, column], currentValue + 1);
                        pointQueue.Enqueue(new int[] { row - 1, column });
                    }
                    if (row < rowCount - 1 && rooms[row + 1, column] == int.MaxValue)
                    {
                        rooms[row + 1, column] = Math.Min(rooms[row + 1, column], currentValue + 1);
                        pointQueue.Enqueue(new int[] { row + 1, column });
                    }
                    if (column < columnCount - 1 && rooms[row, column + 1] == int.MaxValue)
                    {
                        rooms[row, column + 1] = Math.Min(rooms[row, column + 1], currentValue + 1);
                        pointQueue.Enqueue(new int[] { row, column + 1 });

                    }
                    if (column > 0 && rooms[row, column-1] == int.MaxValue)
                    {
                        rooms[row, column - 1] = Math.Min(rooms[row, column - 1], currentValue + 1);
                        pointQueue.Enqueue(new int[] { row, column - 1 });
                    }
                }
            }
        }
    }
}
