using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer_to_English_Words
{
    class Program
    {
        static string[] belowTen = { "","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] belowTwenty = { "Ten","Eleven", "Twelve", "Thirteen", "Fourtenn", "Fifteen", "Sixteen", "SevenTeen", "Eighteen", "Nineteen" };
        static string[] belowHundress = { "","Ten","Twenty", "Thrity", "Fourty", "Fifty", "Sixty", "SevenTy", "Eighty", "Ninety" };
    
        static void Main(string[] args)
        {
            Console.WriteLine(NumberToWords(125455542));
        }

        public static string NumberToWords(int num)
        {
            if (num == 0)
                return "zero";

            if(num <10)
            {
                return belowTen[num];
            }
            else if(num<20)
            {
                return belowTwenty[num%10];
            }
            else if(num<100)
            {
                return belowHundress[num / 10] + belowTen[num % 10];
            }
            else if(num< 1000)
            {
                int hundressDigit = num / 100;
                return NumberToWords(hundressDigit) + " Hundress" + NumberToWords(num % 100);
            }
            else if (num < 1000000)
            {
                int housandDigit = num / 1000;
                return NumberToWords(housandDigit) + " Thosand" + NumberToWords(num % 1000);
            }
            else if (num < 1000000000)
            {
                int housandDigit = num / 1000000;
                return NumberToWords(housandDigit) + " Milion" + NumberToWords(num % 1000000);
            }
            return string.Empty;
        }
    }
}
