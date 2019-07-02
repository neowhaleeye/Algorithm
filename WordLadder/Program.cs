using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            Console.WriteLine(new Solution().LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" }));

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Any(e => e == endWord)) return 0;


            HashSet<string> reached = new HashSet<string>();
            wordList.Add(endWord);
            reached.Add(beginWord);
            HashSet<string> wordDict = new HashSet<string>(wordList);
            int distance = 1;

            while (!reached.Contains(endWord))
            {
                HashSet<string> AddTo = new HashSet<string>();
                foreach (string each in reached)
                {
                    for (int i = 0; i < each.Length; i++)
                    {
                        char[] charArr = each.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            charArr[i] = c;
                            string modWord = new string(charArr);
                            if (wordDict.Contains(modWord))
                            {
                                AddTo.Add(modWord);
                                wordDict.Remove(modWord);
                            }
                        }
                    }
                }

                distance++;
                if (AddTo.Count == 0) return 0;
                reached = AddTo;

            }

            return distance;
        }
    }

}
