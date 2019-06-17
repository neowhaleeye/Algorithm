using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zigzag_Level_Order_Traversal
{ 
      public class TreeNode
     {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
 


    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tn = new TreeNode(1);
            tn.left = new TreeNode(2);
            tn.right = new TreeNode(3);
            tn.left.left = new TreeNode(4);
            tn.right.right = new TreeNode(5);

            new Solution().ZigZageLevelOrder(tn);
        }

        
    }

    public class Solution
    {
        public IList<IList<int>> ZigZageLevelOrder(TreeNode tn)
        {
            
            IList<IList<int>> result = new List<IList<int>>();

            if (tn == null) return result;

            Queue <TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tn);

            bool leftRightDirection = true;
            int depth = 0;
            while(queue.Count>0)
            {
                int queueCount = queue.Count;
                List<int> subVals = new List<int>();
                leftRightDirection = !leftRightDirection;
                for (int i=0;i<queueCount;i++)
                {
                    var node = queue.Dequeue();
                    if (node == null) continue;

                    if (depth % 2 == 0) subVals.Add(node.val);
                    else subVals.Insert(0, node.val);
                                        
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    
                }
                depth++;
                result.Add(subVals);
            }
            return result;
        }

    }
}
