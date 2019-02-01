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
            Console.WriteLine(new Program().AddBinary("1010", "1011"));
                
        }

        public string AddBinary(string a, string b)
        {
           
            int numberLength = Math.Max(a.Length, b.Length);

            a = a.PadLeft(numberLength, '0');
            b = b.PadLeft(numberLength, '0');

            int[] result = new int[numberLength + 1];

            int carry = 0; 
            for (int i = numberLength; i >= 1; i--)
            {
                int sum = Convert.ToInt32(a[i-1].ToString()) + Convert.ToInt32(b[i-1].ToString()) + carry;
                if (sum >= 2) { carry = 1; }
                else { carry = 0; }
                result[i] = sum % 2;
            }

            if (carry == 1)
                result[0] = 1;


            string resultstr = "";
            result.ToList().ForEach(e => resultstr += e);

            return resultstr;
        }
    }
}
