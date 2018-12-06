using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new MyHashSet();
            v.Add(1);
            Console.WriteLine(v.Contain(1));
            Console.WriteLine(v.Contain(2));
            v.Add(2);
            Console.WriteLine(v.Contain(2));
            v.Remove(2);
            Console.WriteLine(v.Contain(2));

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
