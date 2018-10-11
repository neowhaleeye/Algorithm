using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluate_Reverse_Polish_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Solution().EvalRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"}));
 
        }
    }

    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach(string s in tokens)
            {
                switch(s)
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        stack.Push(-1*stack.Pop() + stack.Pop());
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        int n1 = stack.Pop();
                        int n2 = stack.Pop();

                        stack.Push(n2/n1);
                        break;
                    default:
                        stack.Push(Convert.ToInt32(s));
                        break;
                }
            }

            return stack.Pop();
        }
    }
}
