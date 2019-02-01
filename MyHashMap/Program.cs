using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashMap
{
    class Program
    { 
        public class MyKVP<T,K>
        {
            public T Key { get; set; }
            public K Value { get; set; }

            public MyKVP(T key, K value)
            {
                this.Key = key;
                this.Value = value;
            }

            
        }

        public class MyHashMap<T, K> : IEnumerable<MyKVP<T, K>>
            where T : IComparable
        {
            private const int map_size = 5000;
            private List<MyKVP<T,K>>[] storage;

            public MyHashMap()
            {
                
                storage = new List<MyKVP<T, K>>[map_size];
            }

            public IEnumerator<MyKVP<T, K>> GetEnumerator()
            {
                return GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                foreach(var kpvList in storage)
                {
                    if(kpvList != null)
                    {
                        foreach(MyKVP<T,K> kvp in kpvList)
                        {
                            yield return kvp;
                        }
                    }
                }
            }

            private int MyGetHashCode(T key)
            {
                int i = key.GetHashCode();
                if (i < 0) i = i * -1;
                return i / 10000;


            }

            public void Add(T key, K data)
            {
                int value  = MyGetHashCode(key);

                if(storage[value]== null)
                {
                    storage[value] = new List<MyKVP<T, K>>
                    {
                        new MyKVP<T, K>(key, data)
                    };

                   // System.Collections.ICollection

                }
                else
                {
                    //MyKVP<T,K> myKvp = Fnuid
                }
            }
        }



        static void Main(string[] args)
        {
        }
    }
}
