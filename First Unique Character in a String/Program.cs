using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Unique_Character_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstUniqChar2("eeetcode"));
        }

        public static int FirstUniqueChar(string s)
        {
            char[] charArry = s.ToArray();
            var singleChar = charArry.GroupBy(e => e).Where(e => e.ToList().Count == 1).FirstOrDefault();



            if(singleChar != null)
            {
                var selected = singleChar.ToList().FirstOrDefault();
                return s.IndexOf(selected);
            }

            return -1;



        }

        public static int FirstUniqChar2(string s)
        {

            int numberCount = s.Length;
            int[] chars = new int[26];

            

            for (int i = 0; i < numberCount; i++)
            {
                int offsetPos = s[i] - 'a';
                chars[offsetPos]++;
            }

            for (int i = 0; i < numberCount; i++)
            {
                int offsetPos = s[i] - 'a';
                if (chars[offsetPos] == 1)
                    return i;
            }

            return -1;

        }
    }

    
}
