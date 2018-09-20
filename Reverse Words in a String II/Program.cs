using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Words_in_a_String_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var chars = new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
            ReverseWords(chars);
            

        }

        static public void ReverseWords(char[] str)
        {
            Reverse(str, 0, str.Length - 1);

            int start = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == ' ')
                {
                    Reverse(str, start, i - 1);
                    start = i + 1;
                }
            }

            Reverse(str, start, str.Length - 1);

        }

        private static void Reverse(char[] str, int startPos, int endPos)
        {
            while(startPos<endPos)
            {
                char temp = str[startPos];
                str[startPos] = str[endPos];
                str[endPos] = temp;
                startPos++;
                endPos--;
            }

        }
    }
}
