using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            new Solution().AlienOrder(new string[]{ "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"});

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            
            System.Collections.Hashtable dic = new System.Collections.Hashtable();
            int charIndex = 0;
            int loopCount = 0;

          

            foreach (string w in words)
            { 
                if (loopCount == words.Length)
                {
                    charIndex++;
                    loopCount = 0;
                }
                if (w.Length > charIndex)
                {
                    if (!dic.ContainsKey(w[charIndex]))
                    {
                        dic.Add(w[charIndex],0);
                    }
                }
                loopCount++;
            }

            StringBuilder strb = new StringBuilder();
            foreach(var v in dic.Keys)
            {
                strb.Append(v.ToString());
            }

            return strb.ToString();

        }
    }
}
