using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallAndGate
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] ag = new int[,] { {1,-1,0,1 },{ 1,1,1,-1}, {1,-1,1,-1 },{0,-1,1,1 } };
            int[,] ag = new int[,] { { 1 } };
            //int[,] ag = new int[,] { { 1, 2 }, { 3, 4 } };
            new Solution().WallsAndGates(ag);
        }
    }

    public class Solution
    {
        public void WallsAndGates(int[,] rooms)
        {
            int nr = rooms.GetLength(0);
            int nc = rooms.GetLength(1);

            for(int r=0;r<nr;r++)
            {
                for(int c=0;c<nc;c++)
                {
                    if (rooms[r, c] != -1 && rooms[r, c] != 0)
                    {
                        rooms[r, c] = FindShortestPath(rooms, r, c);
                    }
                }
            }

        }

        public int FindShortestPath(int[,] rooms, int r, int c)
        {
            int nr = rooms.GetLength(0);
            int nc = rooms.GetLength(1);

            HashSet<int[]> visied = new HashSet<int[]>();
            Queue<IndexedQueue> queue = new Queue<IndexedQueue>();
            
            int step = 0;
            var v = rooms[r, c];
            queue.Enqueue(new IndexedQueue { Step = step, Points = new int[] { r, c } });

            int finalStepBefore = 0;
            while (queue.Count>0)
            {
                var current = queue.Dequeue();
                int currentRow = current.Points[0];
                int currentColumn = current.Points[1];
                int val = rooms[currentRow, currentColumn];
                visied.Add(new int[] { currentRow, currentColumn });

                if (val == 0)
                {
                    finalStepBefore = current.Step ;
                    break;
                }

              
                AddToQueue(queue, current.Step, rooms, visied, currentRow, currentColumn-1, nr, nc);
                AddToQueue(queue, current.Step, rooms, visied, currentRow, currentColumn+1, nr, nc);
                AddToQueue(queue, current.Step, rooms, visied, currentRow+1, currentColumn, nr, nc);
                AddToQueue(queue, current.Step, rooms, visied, currentRow-1, currentColumn, nr, nc);

            }

            return (finalStepBefore > 0) ? finalStepBefore : v;



        }

        private void AddToQueue(Queue<IndexedQueue> queue, int step, int[,] rooms , HashSet<int[]> visied, int row, int column, int totalRow, int totalColumn)
        {
            if (visied.Any(e => e[0] == row && e[1] == column)) return;
            if (row < 0 || column < 0) return;
            if (totalRow <= row) return;
            if (totalColumn <= column) return;
            if (rooms[row, column] == -1) return;

            queue.Enqueue(new IndexedQueue { Step = step + 1, Points = new int[] { row, column } });

        }
    }

    public struct IndexedQueue
    {
        public int Step { get; set; }
        public int[] Points { get; set; }
    }
}
