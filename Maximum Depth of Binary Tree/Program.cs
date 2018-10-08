using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Depth_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Find(root, 1);
        }

        public int Find(TreeNode root, int level)
        {
            if (root == null)
                return level;

            int levelL = Find(root.left, level + 1);
            int levelR = Find(root.right, level + 1);
            return Math.Max(levelL, levelR);
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
