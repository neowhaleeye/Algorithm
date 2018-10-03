using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new TreeNode(5);
            var n21 = new TreeNode(4);
            var n22 = new TreeNode(8);

            var n31 = new TreeNode(11);
            var n32 = new TreeNode(13);
            var n33 = new TreeNode(4);
            var n41 = new TreeNode(7);
            var n42 = new TreeNode(2);
            var n43 = new TreeNode(1);

            n1.left = n21;
            n1.right = n22;
            n21.left = n31;
            n31.left = n41;
            n31.right = n42;

            n22.left = n32;
            n22.right = n33;
            n33.right = n43;

            //Console.WriteLine(new Solution().HasPathSum(n1, 22));

        }
    }

    public class Solution
    {

        public int total;
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            if (root.val == sum && root.left == null && root.right == null) return true;

            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);


            
        }

        public void CheckValue(TreeNode node, int sum)
        {
            //int offset = sum - node.val;
            //if(node.left != null)
            //{
            //    CheckValue(node.left, offset);
            //}
            //if(node.right != null)
            //{
            //    CheckValue(node.right, offset);
            //}

            //if (offset == 0) hasvalue = true;



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

