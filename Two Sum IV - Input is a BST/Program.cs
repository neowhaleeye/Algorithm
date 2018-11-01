using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sum_IV___Input_is_a_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode t = new TreeNode(5);
            TreeNode t1 = new TreeNode(3);
            TreeNode t2 = new TreeNode(6);
            TreeNode t3 = new TreeNode(2);
            TreeNode t4 = new TreeNode(4);
            TreeNode t5 = new TreeNode(7);

            t.left = t1;
            t.right = t2;
            t1.left = t3;
            t1.right = t4;
            t2.right = t5;

            Console.WriteLine(new Solution().FindTarget(t, 9));
        }
    }

    public class Solution
    {
        public bool FindTarget(TreeNode root, int k)
        {
            List<int> diff = new List<int>();
            return Find(root, k, diff);
        }

        private bool Find(TreeNode root, int k, List<int> dic )
        {
            if (root == null) return false;
            
            int val = root.val;
            bool found = dic.Contains(val);
            if (found) return true;
            dic.Add(k - val);
            return Find(root.left, k, dic) || Find(root.right, k, dic); 

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
