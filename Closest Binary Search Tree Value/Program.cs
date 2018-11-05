using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_Binary_Search_Tree_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            TreeNode sub1 = new TreeNode(2);
            TreeNode sub2 = new TreeNode(5);
            TreeNode sub11 = new TreeNode(1);
            TreeNode sub12 = new TreeNode(3);
            root.left = sub1;
            root.right = sub2;
            sub1.left = sub11;
            sub1.right = sub12;
            Console.WriteLine(new Solution().ClosestValue(root, 3.714d));
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int ClosestValue(TreeNode root, double target)
        {
            
            HashSet<TreeNode> diff = new HashSet<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);

            while(stack.Count>0)
            {
                TreeNode tn = stack.Pop();
                if(diff.Count == 0) diff.Add(tn);
                else
                {
                    if( Math.Abs(tn.val- target) < Math.Abs(diff.Last().val- target))
                    {
                        diff.Add(tn);
                    }
                }

                if(tn.left != null)
                {
                    stack.Push(tn.left);
                }
                if(tn.right != null)
                {
                    stack.Push(tn.right);
                }
            }

            return diff.Last().val;
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
