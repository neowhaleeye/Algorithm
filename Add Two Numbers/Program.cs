using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AddTwoNumbers(new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } },
                new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } });
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //do Recursive
            //assign param to temp variables to do recursive operation.

            ListNode c1 = l1;
            ListNode c2 = l2;
            ListNode result = new ListNode(0);
            //ListNode r = result;
            int sum = 0;

            while(c1 != null && c2 != null)
            {
                int carry = sum / 10;
                sum = carry;

                if(c1 != null)
                {
                    sum += c1.val;
                    c1 = c1.next;
                }

                if(c2 != null)
                {
                    sum += c2.val;
                    c2 = c2.next;
                }

                result.next = new ListNode(sum % 10);
                result = result.next;
            }

            if(sum / 10 ==1)
            {
                result.next = new ListNode(1);
            }

            return result.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
     }
}
