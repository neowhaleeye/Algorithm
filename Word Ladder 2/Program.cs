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
            new Solution().FindLadders1("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog"});
        }
    }

    public class Solution
    {
        public IList<IList<string>> FindLadders1(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> dict = new HashSet<string>(wordList);
            Dictionary<string, List<string>> neighbours = new Dictionary<string, List<string>>();
            Dictionary<string, int> distances = new Dictionary<string, int>();
            dict.Add(beginWord);

            Bfs(beginWord, endWord, dict, neighbours, distances);
            List<string> solutions = new List<string>();
            List<List<string>> res = new List<List<string>>();
            dfs(beginWord, endWord, dict, neighbours, distances, solutions, res);
                

            return null;

        }

        private void dfs(String cur, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance, List<String> solution, List<List<String>> res)
        {
            solution.Add(cur);
            if (end.Equals(cur))
            {
                res.Add(new List<String>(solution));
            }
            else
            {
                foreach (String next in nodeNeighbors[cur])
                {
                    if (distance[next] == distance[cur] + 1)
                    {
                        dfs(next, end, dict, nodeNeighbors, distance, solution, res);
                    }
                }
            }
            solution.RemoveAt(solution.Count - 1);
        }


        private void Bfs(string beginWord, string endWord, HashSet<string> dict, Dictionary<string, List<string>> neighbours, Dictionary<string, int> distance)
        {
            foreach(string s in dict)
            {
                neighbours.Add(s, new List<string>());
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            distance.Add(beginWord, 0);
            
            while(queue.Count>0)
            {
                int count = queue.Count;
                bool found = false;

                for(int i=0;i<count;i++)
                {
                    string cur = queue.Dequeue();
                    int curDist = distance[cur];
                    List<string> neighboureNodes = GetNeighbours(cur, dict);

                    foreach (string n in neighboureNodes)
                    {
                        neighbours[cur].Add(n);
                        if (!distance.ContainsKey(n))
                        {
                            distance.Add(n, curDist + 1);
                            if (n == endWord) found = true;
                            else queue.Enqueue(n);
                        }
                    }

                    if (found) break;
                }
            }

        }

        private List<string> GetNeighbours(string node, HashSet<string> dict)
        {
            List<string> res = new List<string>();
            char[] chs = node.ToCharArray();

            for(char ch='a';ch<='z';ch++)
            {
                for(int i=0;i< chs.Length;i++)
                {
                    if (chs[i] == ch) continue;
                    char old_ch = chs[i];
                    chs[i] = ch;
                    if(dict.Contains(new string(chs)))
                    {
                        res.Add(new string(chs));
                    }
                    chs[i] = old_ch;
                }
            }
            return res;
        }

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
