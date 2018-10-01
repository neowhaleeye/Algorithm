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
        Dictionary<int, List<int?>> values = new Dictionary<int, List<int?>>();
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            CheckNode(root, 1);

            
            bool isSymantic = true;
            foreach(var v in values)
            {
                if (v.Value.Count != Math.Pow(2, v.Key - 1))
                  {
                    isSymantic = false;
                    break;
                }
                for (int i = 0; i < v.Value.Count; i++)
                { 
                    if (v.Value[i] != v.Value[v.Value.Count - i-1])
                    {
                        isSymantic = false;
                        break;
                    }
                }
                if (!isSymantic)
                    break;
            }

            return isSymantic;
            
        }

        

        public void CheckNode(TreeNode node, int level)
        {
            if (values.Any(e => e.Key == level))
            {
                values[level].Add(node?.val);
            }
            else
            {
                values.Add(level, new List<int?>() { node?.val });
            }

            if (node != null)
            {
                CheckNode(node.left, level + 1);
                CheckNode(node.right, level + 1);
            }
            
           

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
