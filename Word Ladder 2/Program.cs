using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Ladder_2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().FindLadders("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog"});
        }
    }

    public class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {

        }

        private bool IsSimilarWord(string s1, string s2)
        {
            int diff = 0;
            for(int i=0;i<s1.Length;i++)
            {
                if (s1[i] != s2[i]) diff++;
                if (diff > 1)
                    break;
            }

            return diff == 0;

        }


    }
}
