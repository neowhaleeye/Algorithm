using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valid_Palindrome_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().ValidPalindrome("abc"));
        }

    }


    public class Solution
    {
        public bool ValidPalindrome(string s)

        {
            int leftPos = -1;
            int rightPos = s.Length;

            while (++leftPos < --rightPos)
            {
                if (s[leftPos] != s[rightPos])
                {
                    return IsPalidrome(s, leftPos + 1, rightPos) || IsPalidrome(s, leftPos, rightPos - 1);
                }

        
            }
            return true;


        }

        private bool IsPalidrome(string s, int leftPos, int rightPos)
        {
            while(++leftPos<--rightPos)
            {
                if (s[leftPos] != s[rightPos])
                {
                    return false;

                }
            }

            return true;
        }
    }

}
