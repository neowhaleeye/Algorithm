using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTIterator

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
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            //          Console.ReadKey();
            TreeNode tn = new TreeNode(7);
            tn.left = new TreeNode(3);
            tn.right = new TreeNode(15);
            tn.right.left = new TreeNode(9);
            tn.right.right = new TreeNode(20);
            new BSTIterator(tn);



            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    class BSTIterator
    {
        
        public BSTIterator(TreeNode root)

        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root;
            while(curr != null)
            {
                stack.Push(curr);
                if (curr.left != null)
                    curr = curr.left;
                else
                    break;
            }
        }
    }
}
