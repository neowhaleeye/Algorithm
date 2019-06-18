using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode second = new ListNode(2);

            ListNode third = new ListNode(3);
            ListNode fourth = new ListNode(4);
            ListNode fifth = new ListNode(5);
            head.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = fifth;


            var newNode = new Solution().ReverseList(head);

        }
    }

    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode newHead = null;
            while(head != null)
            {
                ListNode next = head.next;
                head.next = newHead;
                newHead = head;
                head = next;
            }

            return newHead;
          
           
          
        }

        public ListNode reverseList(ListNode head)
        {
            /* recursive solution */
            return reverseList(head, null);
           
        }

        private ListNode reverseList(ListNode head, ListNode newHead)
        {
            if (head == null) return newHead;

            ListNode next = head.next;
            head.next = newHead;
            return reverseList(next, head);
          
        }

        
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
