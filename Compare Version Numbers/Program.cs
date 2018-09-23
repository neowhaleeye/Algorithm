using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_Version_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompareVersion("7.5.3", "7.5.3.1"));
        }

        public static int CompareVersion(string version1, string version2)
        {
            var version1DigitOnly = version1.Split('.').ToList();
            var version2DigitOnly = version2.Split('.').ToList();

            int diff = Math.Abs(version1DigitOnly.Count - version2DigitOnly.Count);
            List<string> enpty = new List<string>();
            for(int i=0;i<diff;i++)
            {
                enpty.Add("0");
            }

            if(version1DigitOnly.Count> version2DigitOnly.Count)
            {
                version2DigitOnly.AddRange(enpty);
            }
            else  if(version2DigitOnly.Count > version1DigitOnly.Count)
            {
                version1DigitOnly.AddRange(enpty);
            }

            for(int i=0;i< version1DigitOnly.Count;i++)
            {
                if (Convert.ToInt32(version1DigitOnly[i]) > Convert.ToInt32(version2DigitOnly[i]))
                    return 1;
                else if (Convert.ToInt32(version1DigitOnly[i]) < Convert.ToInt32(version2DigitOnly[i]))
                    return -1;

            }


            return 0;

        }
    }
}
