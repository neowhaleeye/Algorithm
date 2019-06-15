using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal


{
    class TreeNode
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
            var v = new Solution().Build(new int[] {9,3,15,20,7 }, new int[] {9,15,7,20,3 });

            int a = 0;


        }


        class Solution
        {
            public TreeNode Build(int[] inorder, int[] postorder)
            {
                if (inorder == null || postorder == null || inorder.Length != postorder.Length)
                    return null;

                //Dictionary<int, int> hm = new Dictionary<int, int>();
                //for(int i=0;i<inorder.Length;i++)
                //{
                //    hm.Add(inorder[i], i);
                //}

                return Build(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
            }

            private TreeNode Build(int[] inorder, int[] postOrder, int iStr, int iEnd, int pStr, int pEnd)
            {
                if (pStr > pEnd) return null;
                int root = postOrder[pEnd];
                TreeNode tn = new TreeNode(root);
                int pos = 0;
                for(int i=iStr;i<=iEnd;i++)
                {
                    if(inorder[i] == tn.val)
                    {
                        pos = i;
                        break;
                    }
                }

                var m1 = pStr + pos - iStr - 1;
                var m2 = pEnd - iEnd + pos;
                tn.left = Build(inorder, postOrder, iStr, pos - 1, pStr, pStr + pos - iStr - 1);
                tn.right = Build(inorder, postOrder, pos + 1, iEnd, pEnd - iEnd + pos, pEnd - 1);
                return tn;
            }
        }
    }
}
