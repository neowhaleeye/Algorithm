using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Root_to_Leaf_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            TreeNode n1 = new TreeNode(9);
            TreeNode n2 = new TreeNode(0);
            TreeNode n11 = new TreeNode(5);
            TreeNode n12 = new TreeNode(1);
            root.left = n1;
            root.right = n2;
            n1.left = n11;
            n1.right = n12;
            Console.WriteLine(SumNumbers(root));
        }

        public static int SumNumbers(TreeNode root)
        {
            return Sum(root, 0);
        }

        private static int Sum(TreeNode node, int s)
        {
            if (node == null) return 0;
            if (node.left == null && node.right == null) return s*10+node.val;
            return Sum(node.left, s * 10 + node.val) + Sum(node.right, s * 10 + node.val);
       
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
           public TreeNode(int x) { val = x; }
  }
    }
}
