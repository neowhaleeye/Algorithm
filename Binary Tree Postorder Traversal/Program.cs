using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Binary_Tree_Postorder_Traversal.Solution;

namespace Binary_Tree_Postorder_Traversal
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

            var list = new Solution().PostorderTraversalIterate(n1);
            list.ToList().ForEach(e => Console.WriteLine(e));
        }
    }

    public class Solution
    {
        List<int> list = new List<int>();
        public IList<int> PostorderTraversal(TreeNode root)
        {
          

            if (root != null)
            {

                if (root.left != null)
                {
                    PostorderTraversal(root.left);
                }
                if (root.right != null)
                {
                    PostorderTraversal(root.right);
                }

                list.Add(root.val);

            }

            return list;
        }

        public IList<int> PostorderTraversalIterate(TreeNode root)
        {
            Stack<object> stack = new Stack<object>();
            List<int> ret = new List<int>();

            stack.Push(root);

            while(stack.Count>0)
            {
                var obj = stack.Pop();

                if (obj == null) continue; 
                if( obj is TreeNode)
                {
                    var tn = obj as TreeNode;
                    stack.Push(tn.val);
                    stack.Push(tn.right);
                    stack.Push(tn.left);

                    
                }
                else
                {
                    ret.Add((int)obj);
                }

            }

            return ret;
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
