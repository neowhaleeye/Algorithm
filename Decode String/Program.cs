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


            Console.WriteLine(new Solution().DecodeString("3[a]4[ab]ccc"));
            //"3[a2[c]]"
        }
    }

    public class Solution
    {
        public string DecodeString(string s)
        {
            StringBuilder ret = new StringBuilder();
            Queue<object> queue = new Queue<object>();
            string number = string.Empty;
            foreach (char c in s.ToCharArray())
            {
                if(Char.IsDigit(c))
                {
                    number += c;
                }
                else if(c == '[')
                {
                    //queue.Enqueue(number);
                }
                else if(c == ']')
                {
                    string chars = string.Empty;
                    while(queue.Count>0)
                    {
                        chars += queue.Dequeue();
                    }
                    for(int i=0;i< Convert.ToInt32(number); i++)
                    {
                        ret.Append(chars);
                    }
                    
                    number = "";
                }
                else
                {
                    queue.Enqueue(c);
                }
            }

            queue.ToList().ForEach(e => ret.Append(queue.Dequeue().ToString()));

            return ret.ToString();

            //if (string.IsNullOrEmpty(s))
            //    return "";

            //List<Dic> list = new List<Dic>();
            //s = "]" + s;
            ////IList<Dic> dic = new List<Dic>();
            //ParseStrig(s, list);


            //StringBuilder strb = new StringBuilder(); 
            //foreach(var v in list)
            //{
            //    for(int i=0;i<v.Number;i++)
            //    {
            //        strb.Append(v.Chars);
            //    }
            //}

            //return strb.ToString();

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
