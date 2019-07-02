using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashMap
{

    public class MyHashMap
    {

        private int bucketSize = 1000;
        private Node[] map;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            map = new Node[bucketSize];
        }

        private int Hash(int key)
        {
            return key % bucketSize;
        }

        private Node Find(Node bucket, int key)
        {
            Node node = bucket;
            Node head = null;

            while(node != null && node.Value != key)
            {
                head = bucket;
                node = node.next;
            }
            return head;
        }


        

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            int index = Hash(key);
            if (map[index] == null)
                map[index] = new Node(-1, -1);

            Node head = Find(map[index], key);
            if (head.next == null)
                head.next = new Node(key, value);
            else
                head.next.Value = value;

        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            int index = Hash(key);
            Node n = map[index];

            if (n == null) return -1;
            Node prev = Find(n, key);
            return prev.next == null ? -1 : prev.next.Value;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            int index = Hash(key);
            Node n = map[index];
            if (n == null) return;

            Node prev = Find(n, key);
            if (prev.next == null) return;
            prev.next = prev.next.next;
        }
    }

    public class Node
    {
        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
        public int Key;
        public int Value;
        public Node next;
       
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */


    class Program
    { 







        static void Main(string[] args)
        {
            var map = new MyHashMap();
            map.Put(1, 1);
            map.Put(2, 2);
            Console.WriteLine(map.Get(1));
            Console.WriteLine(map.Get(3));
            map.Put(2, 1);
            Console.WriteLine(map.Get(2));
            map.Remove(2);
            Console.WriteLine(map.Get(2));
        }
    }
}
