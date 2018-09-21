using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_k_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            var node8 = new ListNode(8);
            var node9 = new ListNode(9);

            node3.next = node1;
            node1.next = node5;

            node2.next = node4;
            node4.next = node6;

            node7.next = node8;
            node8.next = node9;
            

            var result = MergeKLists(new ListNode[] { node7, node3, node2 });
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            var heap = new MinHeap();

            foreach(var node in lists)
            {
                if(node != null)
                {
                    heap.Add(node.val, node);
                }
            }

            ListNode newHead = null;
            ListNode current = null;

            while(heap.map.Count>0)
            {
                ListNode node = heap.PopMin();

                if(current == null)
                {
                    current = node;
                    newHead = current;
                }
                else
                {
                    current.next = node;
                    current = current.next;
                }

            }
           

            return newHead;

            //return result;
        }

       
    }

    public class MinHeap
    {
        /// <summary>
        /// We need to keep track of the heads of all lists at all times and be able 
        /// to do the following operations efficiently:
        /// 1- Get/Remove Min
        /// 2- Add (once you remove the head of one list, you need to add the next from that list)

        /// A min heap (or a priority queue) is obviously the data structure we need here, 
        /// where the key of the dictionary is the value of the ListNode, and the value of the 
        /// dictionary is a queue of ListNodes having that value. (we need to queue the ones with 
        /// the same value since Dictionary cannot have dupes)
        /// 
        /// Using a SortedDictionary of queues.
        /// SortedDictionary is internally implemented using a binary tree, and provides O(logn) 
        /// for Add() and O(1) for PopMin(), so it's as efficient as it gets.
        /// </summary>
        /// 

        public SortedDictionary<int, Queue<ListNode>> map = new SortedDictionary<int, Queue<ListNode>>();

        public void Add(int val, ListNode node)
        {
            if(!map.ContainsKey(val))
            {
                map.Add(val, new Queue<ListNode>());
            }
            map[val].Enqueue(node);
            if(node.next !=null)
            {
                Add(node.next.val, node.next);
            }
        }

        public ListNode PopMin()
        {
            int minKey = map.First().Key;
            var node = map[minKey].Dequeue();

            if(map[minKey].Count ==0)
            {
                map.Remove(minKey);
            }
            return node;
        }
        
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
  }
}
