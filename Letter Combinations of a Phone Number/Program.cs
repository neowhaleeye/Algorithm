using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter_Combinations_of_a_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Solution().LetterCombinations("2345");
            v.ToList().ForEach(e => Console.WriteLine(e));
        }
    }

    public class Solution
    {

        private readonly Dictionary<char, char[]> dic = new Dictionary<char, char[]>();

        public Solution()
        {
            dic.Add('2', new char[] { 'a', 'b', 'c' });
            dic.Add('3', new char[] { 'd', 'e', 'f' });
            dic.Add('4', new char[] { 'g', 'h', 'i' });
            dic.Add('5', new char[] { 'j', 'k', 'l' });
            dic.Add('6', new char[] { 'm', 'n', 'o' });
            dic.Add('7', new char[] { 'p', 'q', 'r', 's' });
            dic.Add('8', new char[] { 't', 'u', 'v' });
            dic.Add('9', new char[] { 'w', 'x', 'y', 'z' });
        }






        public IList<string> LetterCombinations(string digits)
        {
            IList<string> curr = new List<string>();
            if (digits.Length == 0) return curr;

            curr.Add("");
            foreach (char d in digits)
            {
                IList<string> next = new List<string>();
                foreach (char letter in dic[d])
                {
                    foreach (string s in curr)
                    {
                        next.Add(s + letter);
                    }
                }
                curr = next;
            }
            return curr;




        }

        

          
    }

}
