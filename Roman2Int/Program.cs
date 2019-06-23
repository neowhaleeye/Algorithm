using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman2Int
{
    class Program
    {
        static void Main(string[] args)
        {
            new Solution().RomanToInt("MCMXCIV");
        }
    }

    public class Solution
    {
        public int RomanToInt(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            dic.Add("I", 1);
            dic.Add("V", 5);
            dic.Add("X", 10);
            dic.Add("L", 50);
            dic.Add("C", 100);
            dic.Add("D", 500);
            dic.Add("M", 1000);

            Dictionary<string, int> subs = new Dictionary<string, int>();
            subs.Add("IV", 4);
            subs.Add("IX", 9);
            subs.Add("XL", 40);
            subs.Add("XC", 90);
            subs.Add("CD", 400);
            subs.Add("CM", 900);

            int totalNumber = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    string expression = Convert.ToString(s[i]) + Convert.ToString(s[i + 1]);
                    if (subs.ContainsKey(expression))
                    {
                        totalNumber += subs[expression];
                        i = i + 1;
                        continue;
                    }
                }

                totalNumber += dic[Convert.ToString(s[i])];
            }

            return totalNumber;


        }
    }
}
