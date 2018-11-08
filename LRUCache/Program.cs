using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //[[2],[2],[2,6],[1],[1,5],[1,2],[1],[2]]
            //[null,null,null,2,null,null,-1]
            //        [[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]
            var cache = new LRUCache(2);

            cache.Get(1);
            cache.Put(2, 1);
            cache.Get(2);
            cache.Put(3,2);
            Console.WriteLine(cache.Get(3));   // returns 
            cache.Put(3,3);

            Console.WriteLine(cache.Get(2));   // returns 
            Console.WriteLine(cache.Get(3));   // returns 
            //cache.Put(1,1);    // evicts key 2
            ////Console.WriteLine(cache.Get(2));     // returns -1 (not found)
            //cache.Put(4, 1);    // evicts key 1
            //Console.WriteLine(cache.Get(2));    // returns -1 (not found)
            ////Console.WriteLine(cache.Get(3));   // returns 3
            ////Console.WriteLine(cache.Get(4));      // returns 4

        }
    }

    public class LRUCache
    {

        private readonly int capacity;
        private readonly Dictionary<int, LinkedListNode<Tuple<int, int>>> map = new Dictionary<int, LinkedListNode<Tuple<int, int>>>();
        private readonly LinkedList<Tuple<int, int>> lru = new LinkedList<Tuple<int, int>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;

            //LinkedListNode<int> a;
            //LinkedList b;



        }

        public int Get(int key)
        {
            if (!map.TryGetValue(key, out LinkedListNode<Tuple<int, int>> node))
                return -1;

            Touch(node);
            return node.Value.Item2;
        }

        public void Put(int key, int value)
        {
            if (map.TryGetValue(key, out LinkedListNode<Tuple<int, int>> node))
            {
                node.Value = new Tuple<int, int>(key, value);
                Touch(node);
                return;
            }
            EvictIfNeeded();
            node = new LinkedListNode<Tuple<int, int>>(new Tuple<int, int>(key, value));
            lru.AddFirst(node);
            map.Add(key, node);
        }

        private void EvictIfNeeded()
        {
            if (capacity != map.Count) return;
            var tail = lru.Last;
            map.Remove(tail.Value.Item1);
            lru.RemoveLast();
        }

        private void Touch(LinkedListNode<Tuple<int, int>> node)
        {
            lru.Remove(node);
            lru.AddFirst(node);
        }

    }


}
