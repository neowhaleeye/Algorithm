using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)

        {
            Node node = new Node();
            node.val = 1;
            node.children = new List<Node>();

            Node node3 = new Node();
            node3.val = 3;
                
            node3.children = new List<Node>();
            node3.children.Add(new Node { val = 5 });
            node3.children.Add(new Node { val = 6 });


            node.children.Add(node3);
            node.children.Add(new Node { val = 2 });
            node.children.Add(new Node { val = 4 });


             new Codec().serialize(node);
            
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }




    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Codec
    {
        public void Test(int? val)
        {

        }
        // Encodes a tree to a single string.
        public void serialize(Node root)
        {
            Test(null);


            List<string> ret = new List<string>();
            Helper(root, ret);
        }

        private void Helper(Node node, List<string> ret)
        {
            if (node == null) return;

            ret.Add(node.val.ToString());
            if (node.children == null) ret.Add("0");
            else
            {
                ret.Add(node.children.Count.ToString());
                node.children.ToList().ForEach(e => Helper(e, ret));
            }
            
        }

       
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
