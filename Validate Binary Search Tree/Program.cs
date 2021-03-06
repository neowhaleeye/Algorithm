﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode five = new TreeNode(5);
            TreeNode one = new TreeNode(1);
            TreeNode four = new TreeNode(4);
            TreeNode three = new TreeNode(3);
            TreeNode six = new TreeNode(6);

            five.left = one;
            five.right = four;

            four.left = three;
            four.right = six;

            Console.WriteLine(IsValidBST(five));
        }

        public static  bool IsValidBST(TreeNode root)
        {
            return Helper(root, null, null);
        }

        private static bool Helper(TreeNode n, int? minValue, int? maxValue)
        {
            if (n == null) return true;
            
            if ( ( maxValue.HasValue && n.val >= maxValue.Value) || ( minValue.HasValue && n.val <= minValue.Value) ) return false;

            return Helper(n.left, minValue, n.val) && Helper(n.right, n.val, maxValue);
        }

        public bool isValidBST2(TreeNode root)
        {
            if (root == null) return true;
            Stack<TreeNode> node = new Stack<TreeNode>();
            TreeNode previous = null;
            while(root != null || node.Count>0)
            {
                if(root != null)
                {
                    node.Push(root);
                    root = root.left;
                }
                root = node.Pop();
                if (previous != null && previous.val > root.val) return false;
                previous = root;
                root = root.right;
            }
            return true;
            //if (root == null) return true;
            //Stack<TreeNode> stack = new Stack<TreeNode>();
            //TreeNode pre = null;
            //while (root != null || stack.Count>0)
            //{
            //    while (root != null)
            //    {
            //        stack.Push(root);
            //        root = root.left;
            //    }
            //    root = stack.Pop();
            //    if (pre != null && root.val <= pre.val) return false;
            //    pre = root;
            //    root = root.right;
            //}
            //return true;
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
