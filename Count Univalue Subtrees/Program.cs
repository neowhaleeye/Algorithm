using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Univalue_Subtrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var five = new TreeNode(5);
            var one = new TreeNode(1);
            var five2 = new TreeNode(5);
            var five3 = new TreeNode(5);
            var five4 = new TreeNode(5);
            var five5 = new TreeNode(5);

            five.left = one;
            five.right = five2;
            one.left = five3;
            one.right = five4;
            five2.right = five5;

            Console.WriteLine(new Solution().CountUnivalSubtrees(five));

        }
    }

    public class Solution
    {
        public int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null) return 0;

            var result = CheckSubTree(root, root.val) ? 1 : 0;

            return result + CountUnivalSubtrees(root.left) + CountUnivalSubtrees(root.right);
        }

        private bool CheckSubTree(TreeNode node, int val )
        {
            if (node == null) return true;

            return node.val == val && CheckSubTree(node.left, node.val) && CheckSubTree(node.right, node.val);

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
