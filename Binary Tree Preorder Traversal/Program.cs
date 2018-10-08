using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Preorder_Traversal
{
    /// <summary>
    /// PreOrder Traverse mean accessing root first then go to left node of subtree and then right node.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);

            n1.right = n2;
            n2.left = n3;

            var list = PreorderTraversalIterative(n1);

            list.ToList().ForEach(e => Console.WriteLine(e));

        }

        static List<int> r = new List<int>();

        private static IList<int> PreorderTraversalIterative(TreeNode root)
        {
            if (root != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    r.Add(stack.Pop().val);
                    if (root.left != null)
                    {
                        PreorderTraversalIterative(root.left);
                    }
                    if (root.right != null)
                    {
                        PreorderTraversalIterative(root.right);
                    }
                }
            }

            return r;

        }

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();

            if(root == null)
            {
                return result;
            }

            result.Add(root.val); //visit root
            result.AddRange(PreorderTraversal(root.left)); //traverse left subtree
            result.AddRange(PreorderTraversal(root.right)); // traverse right subtree
            
            return result;
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
