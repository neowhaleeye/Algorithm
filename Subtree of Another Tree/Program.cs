using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subtree_of_Another_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode o = new TreeNode(3);
            TreeNode o1= new TreeNode(4);
            TreeNode o2 = new TreeNode(5);
            TreeNode o3 = new TreeNode(1);
            TreeNode o4 = new TreeNode(2);

            o.left = o1;
            o.right = o2;
            o1.left = o3;
            o1.right = o4;

            TreeNode n = new TreeNode(4);
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);

            n.left = n1;
            n.right = n2;

            new Solution().IsSubtree(o, n);

        }
    }

    public class Solution
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return s != null && (IsEqual(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t));
        }

        //public bool Traverse(TreeNode s, TreeNode t)
        //{
            
        //}

        public bool IsEqual(TreeNode s, TreeNode t)
        {
            if (t == null && s == null) return true;
            if (t == null || s == null) return false;
            return s.val == t.val && IsEqual(s.left , t.left) && IsEqual(s.right , t.right);

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

