using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToBase(3499028, 62));
        }

        static string  ToBase(int number, int baseN)
        {
            if (baseN <= 0 || baseN > 62) return string.Empty;

            string baseChar = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int r = number % baseN;
            string res = baseChar[r].ToString();

            int q = number / baseN;
            while(q>0)
            {
                r = q % baseN;
                q = q / baseN;
                res += baseChar[r].ToString();
            }

            return res;

        }
    }
}
