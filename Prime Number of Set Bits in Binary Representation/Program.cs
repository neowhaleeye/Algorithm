using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number_of_Set_Bits_in_Binary_Representation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountPrimeSetBits(6, 10));
        }

        public static int CountPrimeSetBits(int L, int R)
        {
            int totalPrimeNumber = 0;
            
            for(int i=L;i<=R;i++)
            {
                string binary = Convert.ToString(i, 2);
                int countBit = binary.ToCharArray().Where(e => e == '1').Count();

                if(IsPrime(countBit))
                {
                    totalPrimeNumber++;
                }

            }

            return totalPrimeNumber;
        }

        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

    }
}
