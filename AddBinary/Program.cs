using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().AddBinary("11", "1"));
        }

        
    }

    class Solution
    {
        public string AddBinary(string a, string b)
        {

            int lastDigitInA = a.Length - 1;
            int lastDigitInB = b.Length - 1;
            int carry = 0;
            StringBuilder result = new StringBuilder();
            while (lastDigitInA >= 0 || lastDigitInB >= 0)
            {
                int aDigit = 0;
                int bDigit = 0;
                if(lastDigitInA>=0) aDigit = Convert.ToInt32(a[lastDigitInA--].ToString());
                if (lastDigitInB >= 0) bDigit = Convert.ToInt32(b[lastDigitInB--].ToString());

                int sumofDigit = carry + aDigit + bDigit;

                result.Append(sumofDigit % 2);
                carry = sumofDigit / 2;
            }

            if (carry == 1)
                result.Append("1");

            StringBuilder rev = new StringBuilder();
            result.ToString().Reverse().ToList().ForEach(e => rev.Append(e));
            return rev.ToString();

        }
    }
}
