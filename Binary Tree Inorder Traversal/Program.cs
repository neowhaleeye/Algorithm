using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Inorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);

            n1.right = n2;
            n2.left = n3;

            InorderTraversal(n1).ToList().ForEach(e => Console.Write(e));
        }

        static List<int> list = new List<int>();

        public static IList<int> Iternative(TreeNode root)
        {
            Stack<object> stack = new Stack<object>();
            var ret = new List<int>();

            stack.Push(root);

            while(stack.Count>0)
            {
                var element = stack.Pop();
                if (element is null) continue;
                if(element is TreeNode)
                {
                    TreeNode tn = element as TreeNode;
                    stack.Push(tn.right);
                    stack.Push(tn.val);
                    stack.Push(tn.left);
                }
                else
                {
                    ret.Add((int)element);
                }
            }

            return ret;


        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            if (root is null) return list;
            Helper(root);

            return list;
        }

        private static void Helper(TreeNode root)
        {
            if (root is null) return;
            Helper(root.left);
            list.Add(root.val);
            Helper(root.right);
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
