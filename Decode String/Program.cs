using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decode_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //Console.WriteLine(new Solution().DecodeString("13[a]4[ab]ccc"));
            Console.WriteLine(new Solution().DecodeString("3[a2[c]]"));
            Console.WriteLine(new Solution().DecodeString("3[a]2[bc]"));


            
            //"3[a2[c]]"
        }
    }

    public class Solution
    {
        public string DecodeString(string s)
        {
           
            Stack<object> stack = new Stack<object>();
            int curNum = 0;
            string curString = string.Empty;
            foreach (char c in s.ToCharArray())
            {

                if (c == '[')
                {
                    stack.Push(curString);
                    stack.Push(curNum);
                    curString = "";
                    curNum = 0;
                }
                else if (c == ']')
                {
                    int num = Convert.ToInt32(stack.Pop());
                    string preString = stack.Pop().ToString();
                    string build = string.Empty;
                    for(int i=0;i<num;i++)
                    {
                        build += curString;
                    }
                    curString = preString + build;
                }
                else if (char.IsDigit(c))
                {
                    curNum = curNum * 10 + Convert.ToInt32(c.ToString());
                }
                else
                {
                    curString += c;
                }
            }

            return curString;
                
           
           

            

        }

        private void ParseStrig(string s, List<Dic> dic)
        {
            int closeBracet = s.IndexOf(']');
            int openBracet = s.IndexOf('[');
            if (openBracet > -1)
            {
                string number = s.Substring(closeBracet + 1, openBracet - closeBracet - 1);
                int secondcloseBracet = s.IndexOf(']', openBracet);
                string chars = s.Substring(openBracet + 1, secondcloseBracet - openBracet - 1);
                dic.Add(new Dic(Convert.ToInt32(number), chars));
                ParseStrig(s.Substring(secondcloseBracet, s.Length - secondcloseBracet), dic);
            }
            else
            {
                dic.Add(new Dic(1, s.Substring(closeBracet + 1, s.Length - closeBracet - 1)));
            }
       }
    }

    public class Dic
    {
        public Dic(int number, string chars)
        {
            this.Number = number;
            this.Chars = chars;
        }
        public int Number { get; set; }
        public string Chars { get; set; }
    }
}
