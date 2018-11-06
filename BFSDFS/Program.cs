using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            clsGraph graph = new clsGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            //Print adjacency matrix
            graph.PrintAdjacecnyMatrix();

            Console.WriteLine("BFS traversal starting from vertex 2:");
            graph.BFS(2);
            Console.WriteLine("DFS traversal starting from vertex 2:");
            graph.DFS(2);


        }
    }

    class clsGraph
    {
        private int Vertices;
        private List<int>[] Adjency;

        public clsGraph(int v)
        {
            Vertices = v;
            Adjency = new List<int>[v];
            for(int i=0;i<v;i++)
            {
                Adjency[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            Adjency[v].Add(w);
        }

        public void BFS(int s)
        {
            bool[] visited = new bool[Vertices];
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while(queue.Count>0)
            {
                s = queue.Dequeue();
                Console.WriteLine("next->{0}", s);
                foreach(int next in Adjency[s])
                {
                    if(!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
        }

        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while(stack.Count>0)
            {
                s = stack.Pop();
                Console.WriteLine("next->{0}", s);
                foreach(int next in Adjency[s])
                {
                    if(!visited[next])
                    {
                        visited[next] = true;
                        stack.Push(next);
                    }
                }
            }
        }

        public void PrintAdjacecnyMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in Adjency[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }

    }
}
