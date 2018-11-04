using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inorder_Successor_in_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(10);
            TreeNode t2 = new TreeNode(4);
           TreeNode t3 = new TreeNode(12);

            TreeNode t4 = new TreeNode(2);
            TreeNode t5 = new TreeNode(6);

            TreeNode t6 = new TreeNode(11);
            TreeNode t7 = new TreeNode(13);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t2.right = t5;

            t3.left = t6;
            t3.right = t7;


            TreeNode compare = new TreeNode(2);
            Console.WriteLine(new Solution().InorderSuccessor(t1, compare).val);
        }
    }

    public class Solution
    {
        List<int> nodeVal = new List<int>();
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            TreeNode succ = null;
            while (root != null)
            {
                if (p.val < root.val)
                {
                    succ = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }

            }

            return succ;
        }

    
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
