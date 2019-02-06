using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("aaabbaaa"));
            //BruteForce("aba");
            //BruteForce("aaabaaaa");
        }

        public static void BruteForce(string s)
        {
            List<string> splited = new List<string>();
            List<string> palidromicExpression = new List<string>();

            for (int i= 2; i <= s.Length;i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (j <= s.Length - i)
                    {
                        splited.Add(s.Substring(j, i));
                    }
                }
            }


            foreach(var ss in splited)
            {
                if(IsP(ss))
                {
                    palidromicExpression.Add(ss);
                }
            }

            

            //palidromicExpression.OrderByDescending(e=>e.Count)


        }

        private static bool IsP(string s)
        {
            int leftIdex = 0;
            int rightIndex = s.Length - 1;

            bool isP = false;
            while(leftIdex<=rightIndex)
            {
                if(s[leftIdex] == s[rightIndex])
                {
                    isP = true;
                    leftIdex++;
                    rightIndex--;
                }
                else
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }

        public static String LongestPalindrome(String s)
        {
            if (s == null) return null;
            if (s.Length < 2) return s;

            int start = 0, end = 0;
            for(int i=0;i<s.Length;i++)
            {
                int len1 = Expands(s, i, i);
                int len2 = Expands(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if(len > end-start)
                {
                    start = i - (len - 1) / 2;
                    end = i + (len / 2);
                }
            }


            return s.Substring(start, end-start+1);
            //return s.Substring(start, end);

        }

        private static int Expands(string s, int leftPos, int rightPos)
        {
            

            int left = leftPos;
            int right = rightPos;
            while(left >= 0 && right <= s.Length-1 && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
        


    }
}
