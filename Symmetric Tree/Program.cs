using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symmetric_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode t1 = new TreeNode(1);
            //TreeNode t2 = new TreeNode(2);
            //TreeNode t22 = new TreeNode(2);
            //TreeNode t3 = new TreeNode(3);
            //TreeNode t4 = new TreeNode(4);
            //TreeNode t44 = new TreeNode(4);
            //TreeNode t33 = new TreeNode(3);

            //t1.left = t2;
            //t1.right = t22;
            //t2.left = t3;
            //t2.right = t4;
            //t22.left = t44;
            //t22.right = t33;

            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(2);
            TreeNode t22 = new TreeNode(2);
            TreeNode t3 = new TreeNode(3);
            TreeNode t33 = new TreeNode(3);

            t1.left = t2;
            t1.right = t22;
            t2.right = t3;
            t22.left = t33;

         

            Console.WriteLine(new Solution().IsSymmetric(t1));
        }
    }

    public class Solution
    {
        //Dictionary<int, List<int?>> values = new Dictionary<int, List<int?>>();
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            //return CheckNode(root.left, root.right);

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }
                if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }

                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);

            }

            return true;

        }

        

        public bool CheckNode(TreeNode left, TreeNode right)
        {
            if(left == null || right == null)
            {
                bool b = left == right;
                return b;
            }

            if(left.val != right.val)
            {
                return false;
            }

            return CheckNode(left.left, right.right) && CheckNode(left.right, right.left);
            
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
