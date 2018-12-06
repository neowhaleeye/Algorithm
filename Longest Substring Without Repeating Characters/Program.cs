using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Solution().LengthOfLongestSubstring("abcabcotpq"));
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0;
            HashSet<char> set = new HashSet<char>();

            int i = 0, j = 0;
            while (i < n && j < n)
            {
                if(!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }

            return ans;
        }
    }
}
