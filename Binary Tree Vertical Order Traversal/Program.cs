using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Vertical_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TreeNode t1 = new TreeNode(3);
            TreeNode t2 = new TreeNode(9);
            TreeNode t3 = new TreeNode(20);
            TreeNode t4 = new TreeNode(15);
            TreeNode t5 = new TreeNode(7);

            t1.left = t2;
            t1.right = t3;
            t3.left = t4;
            t3.right = t5;

            var r = new Solution().VerticalOrder(t1);

            for(int i=0;i<r.Count;i++)
            {
                Console.WriteLine();
                r[i].ToList().ForEach(e => Console.Write(e+ ","));
            }
            //3,9,20,null,null,15,7
        }
    }

    public class Solution
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {

            if (root == null) return new List<IList<int>>();

            Queue<TreeNode> treeNodeQ = new Queue<TreeNode>();
            Queue<int> columns = new Queue<int>();
            Dictionary<int, List<TreeNode>> dic = new Dictionary<int, List<TreeNode>>();

            treeNodeQ.Enqueue(root);
            columns.Enqueue(0);

            while (treeNodeQ.Count > 0)
            {
                TreeNode tn = treeNodeQ.Dequeue();
                int currentColumn = columns.Dequeue();

                if(!dic.ContainsKey(currentColumn))
                {
                    dic.Add(currentColumn, new List<TreeNode>() { tn });
                }
                else
                {
                    dic[currentColumn].Add(tn);
                }

                if(tn.left != null)
                {
                    treeNodeQ.Enqueue(tn.left);
                    columns.Enqueue(currentColumn - 1);
                }

                if(tn.right != null)
                {
                    treeNodeQ.Enqueue(tn.right);
                    columns.Enqueue(currentColumn + 1);
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            foreach (var d in dic.OrderBy(e => e.Key))
            {
                List<int> nodes = d.Value.Select(e => e.val)?.ToList();
                result.Add(nodes);
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
