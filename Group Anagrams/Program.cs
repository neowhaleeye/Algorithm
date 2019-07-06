using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();

            foreach (string s in strs)
            {
                int key = GetKey(s);
                if (map.ContainsKey(key))
                {
                    map[key].Add(s);
                }
                else
                {
                    map.Add(key, new List<string> { s });
                    
                }
            }

            return null;
        }

        private int GetKey(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += s[i] - 'a';
            }

            return sum;
        }
    }
}
