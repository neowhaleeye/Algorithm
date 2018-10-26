using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection_of_Two_Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode a1 = new ListNode(1);
            ListNode a2 = new ListNode(2);
            ListNode c1 = new ListNode(3);
            ListNode c2 = new ListNode(2);
            ListNode c3 = new ListNode(3);
            ListNode b1 = new ListNode(1);
            ListNode b2 = new ListNode(2);
            ListNode b3 = new ListNode(3);

            a1.next = a2;
            a2.next = c1;
            c1.next = c2;
            c2.next = c3;
            b1.next = b2;
            b2.next = b3;
            b3.next = c1;

            var interesction = new Solution().GetIntersectionNodeTwoPoint(a1, b1);
            Console.WriteLine(interesction.val);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public ListNode GetIntersectionNodeTwoPoint(ListNode headA, ListNode headB)
        {
            ListNode a = headA;
            ListNode b = headB;

            int aCount = 0;
            while (a != null)
            {
                aCount++;
                a = a.next;
            }

            int bCount = 0;
            while (b != null)
            {
                bCount++;
                b = b.next;
            }

            a = headA;
            b = headB;

            if (aCount > bCount)
            {
                int diff = aCount - bCount;
                for (int i = 0; i < diff; i++)
                {
                    a = a.next;
                }
            }
            else if (bCount > aCount)
            {
                int diff = bCount - aCount;
                for (int i = 0; i < diff; i++)
                {
                    b = b.next;
                }
            }

            while (a != b)
            {
                a = a.next;
                b = b.next;
            }

            return a;

        }


        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            
            ListNode a = headA;
            ListNode b = headB;
            HashSet<ListNode> dic = new HashSet<ListNode>();
            ListNode matched = null;
            while (a != null || b != null)
            {
                if(a != null)
                {
                    if (!dic.Contains(a))
                        dic.Add(a);
                    else
                    {
                        matched = a;
                        break;
                    }
                    a = a.next;
                }
                if(b != null)
                {
                    if (!dic.Contains(b))
                        dic.Add(b);
                    else
                    {
                        matched = b;
                        break;
                    }
                    b = b.next;
                }
            }

            return matched;

        }
    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }
}
