using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kthLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            var k = new KthLargest(3, new int[] { 4,5,8,2});
            k.add(3);
            k.add(5);
            k.add(10);
            k.add(9);
            k.add(4);

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

    }

    class KthLargest
    {
        private Node root;
        private int k;

        public KthLargest(int k, int[] nums)
        {
            root = null;
            for (int i = 0; i < nums.Length; ++i)
            {
                root = insert(root, nums[i]);
            }
            this.k = k;
        }

        public int add(int val)
        {
            root = insert(root, val);
            return findKth(root, k);
        }

        public Node insert(Node root, int num)
        {
            if (root == null)
                return new Node(num, 1);
            if (root.val > num)
                root.left = insert(root.left, num);
            else
                root.right = insert(root.right, num);
            root.count++;
            return root;
        }

        public int findKth(Node root, int k)
        {
            int m = root.right != null ? root.right.count+1 : 0;
            if (k == m)
                return root.val;
            if (k < m)
            {
                return findKth(root.right, k);
            }
            else
            {
                return findKth(root.left, k - m);
            }
        }
    }

    class Node
    {
        public Node left;
        public Node right;
        public int val;
        public int count;
        public Node(int v, int c)
        {
            val = v;
            count = c;
        }
    }




    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */

}
