using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Most_Common_Word
{
    class Program
    {
        static void Main(string[] args)

        {
             
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string s = "a, a, a, a, b,b,b,c, c";

            IList<char> puctuations = GetPuctuation(s);
            puctuations.Add(' ');

            var p = s.Split(puctuations.ToArray());

            
            string[] ban = new string[] { "a" };


            foreach (string word in p)
            {

                string lword = word.ToLower();

                bool bannedWord = false;
                foreach (string b in ban)
                {
                    if (b.ToLower() == lword)
                    {
                        bannedWord = true;
                        break;
                    }
                }
                if (bannedWord || lword.Length == 0) continue;




                if (!dic.ContainsKey(lword))
                {
                    dic.Add(lword, 1);
                }
                else
                {
                    dic[lword]++;
                }
            }


            string sss = dic.OrderByDescending(e => e.Key).OrderByDescending(e => e.Value).First().Key;

        }


        private static IList<char> GetPuctuation(string str)
        {
            char[] charArray = str.ToCharArray();
            var puctuations = charArray.Where(e => Char.IsPunctuation(e));
            return puctuations.ToList();
        }
    }
}
