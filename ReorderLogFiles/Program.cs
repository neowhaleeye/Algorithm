using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderLogFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new string[] { "1 n u", "r 527", "j 893", "6 14", "6 82" };
            var r = new Solution().ReorderLogFiles(p);

        }
    }

    public class Solution
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            List<Log> hashs = new List<Log>();
            
            foreach(string log in logs)
            {
                hashs.Add(new Log(log));
            }

            hashs.Sort();

            return hashs.Select(e => e.OriginalString).ToArray();
            

        }
    }

    public class Log : IComparable<Log>
    {
        

        public Log(string str)
        {
            this.OriginalString = str;
            string[] logElements = str.Split(' ');
            this.Identifier = logElements[0];
            this.Elements = logElements.Skip(1).ToList();
        }
        public string Identifier { get; set; }
        public string CompressedExpression { 
            get
            {
                StringBuilder strb = new StringBuilder();
                Elements.ToList().ForEach(e => strb.Append(e));
                return strb.ToString();
            }
        }
        public string OriginalString { get; set; }
        public IList<string> Elements { get; set; }
        public bool IsNumericElement
        {
            get
            {
                int num;
                return int.TryParse(Elements.First(), out num);
            }
        }




        

        public int CompareTo(Log other)
        {
            if (this.IsNumericElement && !other.IsNumericElement)
                return 1;
            if (!this.IsNumericElement && other.IsNumericElement)
                return -1;

            
            int min = Math.Min(this.Elements.Count, other.Elements.Count);
            int idx = 0;
            int compare = 0;
            do
            {
                compare = this.Elements[idx].CompareTo(other.Elements[idx]);
                idx++;
            }
            while (compare == 0 && idx<min);

            if (compare == 0)
                return this.Identifier.CompareTo(other.Identifier);

            if (this.IsNumericElement) return compare * -1;
            return compare;

        }
    }
}
