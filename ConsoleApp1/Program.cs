using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }
        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
        public Node(int _val)
        {
            val = _val;
        }
    }

    public class Solution
    {
        private Dictionary<Node, Node> dic = new Dictionary<Node, Node>();

        public Node CopyRandomListRecursive(Node head)
        {
            if (head == null) return null;
            if(dic.ContainsKey(head))
            {
                return dic[head];
            }

            Node copy = new Node { val = head.val };
            dic.Add(head, copy);

            copy.next = CopyRandomListRecursive(head.next);
            copy.random = CopyRandomListRecursive(head.random);

            return copy;
        }

        public Node CopyRamdomlistHash(Node head)
        {
            if (head == null) return null;

            Node oldnode = head;
            Node newnode = new Node { val = oldnode.val };
            dic.Add(oldnode, newnode);

            while(oldnode != null)
            {
                newnode.random = GetCloneNode(oldnode.random);
                newnode.next = GetCloneNode(oldnode.next);

                oldnode = oldnode.next;
                newnode = newnode.next;
            }

            return dic[head];
        }

        private Node GetCloneNode(Node node)
        {
            if (node == null) return null;

            if(dic.ContainsKey(node))
            {
                return dic[node];
            }
            Node newnode = new Node { val = node.val };
            dic.Add(node, newnode);
            return dic[node];
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            Node ptr = head;
            while(ptr != null)
            {
                Node next = ptr.next;
                Node copy = new Node { val = ptr.val };
                copy.next = next;
                ptr.next = copy;
                ptr = next;
            }

            ptr = head;
            while(ptr != null)
            {
                Node copy = ptr.next;
                copy.random = (ptr.random != null) ? ptr.random.next : null;
                ptr = ptr.next.next;
            }

            Node ptr_old_list = head;
            Node ptr_new_list = head.next;
            Node new_node = head.next;

            while(ptr_old_list != null)
            {
                ptr_old_list.next = ptr_old_list.next.next;
                ptr_new_list.next = ptr_new_list.next.next;
                ptr_old_list = ptr_old_list.next;
                ptr_new_list = ptr_new_list.next;
            }

            return new_node;
           









        }
    }

    class Program
    {
        static void Main(string[] args)

        {
            Node n1 = new Node { val = 1 };
            Node n2 = new Node { val = 2 };
            n1.next = n2;
            n1.random = n2;
            n2.random = n2;

            new Solution().CopyRamdomlistHash(n1);
        // The code provided will print ‘Hello World’ to the console.
        // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
        }

        

    }
    
}