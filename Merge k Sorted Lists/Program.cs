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
            var v = new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } };
            var vv = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } };
            var vvv = new ListNode(2) { next = new ListNode(6)  };
            ListNode[] n = new ListNode[] { v,vv,vvv};
            MergeKLists(n);
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = new ListNode(0);
            ListNode r = result;
            for(int i=0;i<lists.Length;i++)
            {
                ListNode l = lists[i];
                while(l != null)
                {
                   
                        r.next = l;
                    
                    r = r.next;
                    l = l.next;
                }
            }

            return result;
            
        }

         
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
  }
}
