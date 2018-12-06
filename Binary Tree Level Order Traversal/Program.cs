using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Level_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n3 = new TreeNode(3);
            TreeNode n9 = new TreeNode(9);
            TreeNode n20 = new TreeNode(20);
            TreeNode n15 = new TreeNode(15);
            TreeNode n7 = new TreeNode(7);
            n3.left = n9;
            n3.right = n20;
            n20.left = n15;
            n20.right = n7;

            var list = new Solution().LO(n3);

            list.ToList().ForEach(e => e.ToList().ForEach(ee => Console.WriteLine(ee)));
        }
        
    }

    public class Solution
    {

        public IList<IList<int>> LO(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> nodeQ = new Queue<TreeNode>();
            Queue<int> lvlQ = new Queue<int>();

            nodeQ.Enqueue(root);
            lvlQ.Enqueue(0);
            while (nodeQ.Count > 0)
            {
                var node = nodeQ.Dequeue();
                var lvl = lvlQ.Dequeue();

                if (result.Count > lvl)
                {
                    result[lvl].Add(node.val);
                }
                else
                {
                    result.Add(new List<int>() { node.val });
                }

                if (node.left != null)
                {
                    nodeQ.Enqueue(node.left);
                    lvlQ.Enqueue(lvl + 1);
                }
                if (node.right != null)
                {
                    nodeQ.Enqueue(node.right);
                    lvlQ.Enqueue(lvl + 1);
                }
            }

            return result;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            

            

            Queue<TreeNode> q = new Queue<TreeNode>();
            Queue<int> level = new Queue<int>();

            q.Enqueue(root);
            level.Enqueue(0);

            while (q.Count > 0)
            {
                TreeNode temp = q.Dequeue();
                int l = level.Dequeue();

                if(result.Count>l)
                {
                    result[l].Add(temp.val);
                }
                else
                {
                    result.Add(new List<int>() { temp.val });
                }

                if(temp.left != null)
                {
                    q.Enqueue(temp.left);
                    level.Enqueue(l + 1);
                }
                if(temp.right != null)
                {
                    q.Enqueue(temp.right);
                    level.Enqueue(l + 1);
                }
            }

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

