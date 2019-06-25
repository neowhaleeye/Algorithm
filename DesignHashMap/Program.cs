using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHash
{
    //https://www.hackerearth.com/practice/data-structures/hash-tables/basics-of-hash-tables/tutorial/

    class Program
    {
        static void Main(string[] args)
        {
            //var v = new MyHashSet();
            //v.Add(1);
            //Console.WriteLine(v.Contain(1));
            //Console.WriteLine(v.Contain(2));
            //v.Add(2);
            //Console.WriteLine(v.Contain(2));
            //v.Remove(2);
            //Console.WriteLine(v.Contain(2));

            MyHashMap map = new MyHashMap();
            //map.Put(1, 1);
            //map.Get(1);
            map.Put(2, 3);
            map.Get(2);
            map.Put(2,4);
            map.Get(2);
            map.Put(1002, 5);
            map.Get(1002);


        }
    }

    class MyHashMap
    {
        public ListNode[] bucketList = new ListNode[1000];
        public void Put(int key, int value)
        {
            int bucketIndex = Index(key);
            if (bucketList[bucketIndex] == null)
                bucketList[bucketIndex] = new ListNode(-1, -1);

            ListNode prev = find(bucketList[bucketIndex], key);
            if(prev.next == null)
            {
                prev.next = new ListNode(key, value);
            }
            else
            {
                prev.next.value = value;
            }
           

        }

        public int Get(int key)
        {
            int bucketIndex = Index(key);
            if (bucketList[bucketIndex] == null)
                return -1;
            ListNode node = find(bucketList[bucketIndex], key);
            return node.next == null ? -1 : node.next.value;
        }

        public void Remove(int key)
        {
            int i = Index(key);
            if (bucketList[i] == null)
                return;
            ListNode prev = find(bucketList[i], key);
            if (prev.next == null) return;
            prev.next = prev.next.next;
        }

        int Index(int key)
        {
            return key % bucketList.Length;
        }

        ListNode find(ListNode bucket, int key)
        {
            ListNode node = bucket;
            ListNode prev = null;

            while(node != null && node.key != key)
            {
                prev = node;
                node = node.next;
            }
            return prev;
            

        }

    }

    public class ListNode
    {
        public int key, value;
        public ListNode next;
        public ListNode(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class MyHashSet
    {
        public const int bucket = 1000;
        public const int ItemInBucket = 1000;
        public bool[,] table;
        public MyHashSet()
        {
            table = new bool[bucket, ItemInBucket];
        }

        private int Hash(int key)
        {
            return key % bucket;
        }

        private int Pos(int key)
        {
            return key / bucket;
        }


        public void Add(int key)
        {
            int bucketNumber = Hash(key);
            table[bucketNumber, Pos(key)] = true;
        }

        public void Remove(int key)
        {
            int bucketNumber = Hash(key);
            table[bucketNumber, Pos(key)] = false;
        }

        public bool Contain(int key)
        {
            int bucketNumber = Hash(key);
            return table[bucketNumber, Pos(key)];
        }
    }
}
