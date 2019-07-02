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
            var cache = new LRUCache4(2);

            int i = cache.Get(1);
            cache.Put(2, 1);
            cache.Put(4, 1);
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

    public class LRUCache1
    {
        private int[] bucket;
        private Queue<int> queue = new Queue<int>();

        public LRUCache1(int capacity)
        {
            bucket = new int[capacity];
            for(int i=0;i<bucket.Length;i++)
            {
                bucket[i] = int.MinValue;
            }
        }


        public int Hash(int key)
        {
            return key % bucket.Length;
        }


        public int Get(int key)
        {
            
            int index = Hash(key);
            
            return bucket[index];
        }

        public void Put(int key, int value)
        {
            int index = Hash(key);
            bucket[index] = value;
            

        }
    }

    public class Node
    {
        public int Key;
        public int Value;
        public Node Pre;
        public Node Next;

        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class LRUCache4
    {
        public Node1[] dic;
        private Node1 header;
        private Node1 tail;
        private int capacity;
        private int itemCount;


        public LRUCache4(int capacity)
        {
            dic = new Node1[1001];
            this.capacity = capacity;
            header = new Node1(-1, -1);
            tail = new Node1(-1, -1);
            header.next = tail;
            tail.prev = header;
        }

        private void AddToHeader(Node1 node)
        {
            node.next = header.next;
            node.next.prev = node;
            node.prev = header;
            header.next = node;

        }

        private void RemoveNode(Node1 node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private int Hash(int key)
        {
            return key % 1001;
        }

        public int Get(int key)
        {
            int index = Hash(key);
            if (dic[index] == null) return -1;
            Node1 n = dic[index];
            int result = n.value;

            RemoveNode(n);
            AddToHeader(n);

            return result;
        }

        private Node1 Find(Node1 node, int key)
        {
            Node1 n = node;
            Node1 prev = null;
            while (n != null && n.key != key)
            {
                prev = n;
                n = n.next;
            }
            return prev;
        }

        public void Put(int key, int value)
        {
            int index = Hash(key);
            if (dic[index] == null)
            {
                Node1 newnode = new Node1(key, value);
                dic[index] = newnode;
                itemCount++;
                AddToHeader(newnode);

                if(itemCount > capacity)
                {
                    dic[tail.prev.key] = null;
                    RemoveNode(tail.prev);
                }
            }
            else
            {
                Node1 n = dic[index];
                n.value = value;
                RemoveNode(n);
                AddToHeader(n);
            }
            
            
            //RemoveNode(prev.next);
            //AddToHeader(prev.next);
        }
    }

    public class Node1
    {
        public Node1(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
        public int key { get; set; }
        public int value { get; set; }
        public Node1 next;
        public Node1 prev;
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */


    public class LRUCache2
    {
        private Dictionary<int, Node> dic;
        private int capacity;
        private Node head, tail;

        public LRUCache2(int capacity)
        {
            this.capacity = capacity;
            dic = new Dictionary<int, Node>();
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.Next = tail;
            tail.Pre = head;
        }

        private void RemoveNode(Node node)
        {
            node.Pre.Next = node.Next;
            node.Next.Pre = node.Pre;
        }

        private void AddToHead(Node node)
        {
            node.Next = head.Next;
            node.Next.Pre = node;
            node.Pre = head;
            head.Next = node;
        }

        public int get(int key)
        {
           if(dic.ContainsKey(key))
            {
                int result = dic[key].Value;
                RemoveNode(dic[key]);
                AddToHead(dic[key]);
                return result;
            }
            return -1;
        }

        public void Add(int key, int value)
        {
            if(!dic.ContainsKey(key))
            {  
                Node newnode = new Node(key, value);
                dic.Add(key, newnode);
                AddToHead(newnode);

                if (dic.Count > capacity)
                {
                    dic.Remove(tail.Pre.Key);
                    RemoveNode(tail.Pre);
                }
            }
            else
            {
                Node node = dic[key];
                node.Value = value;
                RemoveNode(node);
                AddToHead(node);

            }

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
