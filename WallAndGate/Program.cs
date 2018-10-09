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
            int[,] ag = new int[,] { {1,-1,0,1 },{ 1,1,1,-1}, {1,-1,1,-1 },{0,-1,1,1 } };
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
                    int a = FindShortestPath(rooms, r, c);
                }
            }
            //for loop
            // call from point (0,0) 
            //for(int i=0l)

        }

        public int FindShortestPath(int[,] rooms, int r, int c)
        {
            int nr = rooms.GetLength(0);
            int nc = rooms.GetLength(1);
            Queue<int[]> queue = new Queue<int[]>();
            Queue<int> stepQueue = new Queue<int>();

            var v = rooms[r, c];
            queue.Enqueue(new int[] { r,c });

            int step = 0;

            while(queue.Count>0)
            {
                
                var pop = queue.Dequeue();
                int rPop = pop[0];
                int cPop = pop[1];
                int val = rooms[rPop, cPop];

                if (val == 0)
                    break;

                if (nr > rPop && nc > cPop && val == 1 )
                {
                    queue.Enqueue(new int[] { rPop, cPop + 1  });
                    queue.Enqueue(new int[] { rPop + 1, cPop + 1  });
                    queue.Enqueue(new int[] { rPop + 1, cPop });
                }

                

                
            }

            return step;



        }
    }
}
