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

            IList<IList<string>> ladders = new List<IList<string>>();
            if (!wordList.Contains(endWord))
                return ladders;
            var wqueue = new Queue<string>();
            var wordls = new List<string>(wordList);
            int maxpath = int.MaxValue;
            wqueue.Enqueue(beginWord);
            while (wqueue.Count != 0)
            {
                var cvisitedList = new HashSet<string>();
                var cqueueList = new HashSet<string>();
                while (wqueue.Count != 0)
                {
                    var cwordls = wqueue.Dequeue();
                    var words = cwordls.Split(',');
                    var word = words.Last();
                    foreach (var item in wordls.Where(x => isLadderWord(word, x)))
                    {
                        cvisitedList.Add(item);
                        if (maxpath <= words.Length - 1)
                            continue;
                        if (item.Equals(endWord))
                        {
                            var nwordls = new List<string>(words);
                            nwordls.Add(item);
                            ladders.Add(nwordls);
                            maxpath = words.Length + 1;
                            continue;
                        }
                        cqueueList.Add(cwordls + "," + item);
                    }
                }
                wordls.RemoveAll(x => cvisitedList.Contains(x));
                cqueueList.ToList().ForEach(x => wqueue.Enqueue(x));
            }
            return ladders;



        }

        private bool isLadderWord(string s1, string s2)
        {
            int diff = 0;
            for(int i=0;i<s1.Length;i++)
            {
                if (s1[i] != s2[i]) diff++;
                if (diff > 1)
                    break;
            }

            return diff == 1;

        }


    }
}
