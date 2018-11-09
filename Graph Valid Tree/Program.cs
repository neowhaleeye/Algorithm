using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Valid_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] edges = new int[,] { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 1, 3 },{ 1,4} };

            Console.WriteLine(new Solution().Valid(5, edges));
        }
    }

    public class Solution
    {
        int[] parents;
        public bool ValidTree(int n, int[,] edges)
        {
            int edgeCount = edges.Length / 2;

            if (edgeCount != n - 1) return false;
            parents = new int[n];
            for (int i = 0; i < n; i++) parents[i] = -1;

            for(int i=0;i<edgeCount;i++)
            {
                int ele1 = edges[i, 0];
                int ele2 = edges[i, 1];

                int f1 = Find(ele1);
                int f2 = Find(ele2);
                if (f1 == f2) return false;
                else
                    Union(ele1, ele2);

            }

            return true;

        }

        private int Find(int element)
        {
            if (this.parents[element] == -1)
            {
                return element;
            }
            else
                return Find(parents[element]);
        }

        private void Union(int elementOne, int elementTwo)
        {
            int parentOne = Find(elementOne);
            int parentTwo = Find(elementTwo);

            parents[parentOne] = parentTwo;
        }



        public bool Valid(int n, int[,] edges)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                map.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                map[i].Add(edges[i, 0]);
                map[i].Add(edges[i, 1]);
            }

            bool[] visited = new bool[n];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int top = queue.Dequeue();
                if (visited[top])
                {
                    return false;
                }

                visited[top] = true;
                for (int i = 0; i < map[i].Count; i++)
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }

            foreach(bool b in visited)
            {
                if (!b)
                    return false;
            }

            return true;

            

        }
    }
}
