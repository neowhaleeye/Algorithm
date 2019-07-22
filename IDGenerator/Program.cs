using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrntl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            SimpleStackGenerator gen = new SimpleStackGenerator();
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            gen.Remove(2);
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            Console.WriteLine(gen.Get());
            gen.Remove(3);
            Console.WriteLine(gen.Get());
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    public class SimpleStackGenerator
    {
        Stack<int> removed = new Stack<int>();
        int seed = 0;

        public void Remove(int i)
        {
            removed.Push(i);
        }
        public int Get()
        {
            if(removed.Count>0)
            {
                return removed.Pop();
            }

            seed++;
            return seed;
        }

    }
        
    

    public class Node
    {
        public int key;
        public int val;
        public Node(int key)
        {
            this.key = key;
            
        }

        public Node prev;
        public Node next;
    }

    public class IDGenerator
    {

        private Node removed;
        private int LastIndex = 0;
        
        public IDGenerator()
        {
            this.removed = new Node(1);
        }

        private void AddToHead(Node node)
        {
            
            node.next = removed.next;
            this.removed.next = node;
        }

        
        

        public int Get()
        {
            if(this.removed.next != null)
            {
               
                int ret = this.removed.next.key;
                this.removed.next = this.removed.next.next;
                return ret;
              
            }
            LastIndex = (LastIndex + 1);
            return LastIndex;
        }

        public void Remove(int i)
        {
            Node newnode = new Node(i);
            AddToHead(newnode);
           
        }
    }

}
