using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_of_Array_Except_Self
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbs = new int[] { 1, 2, 3, 4 };

            // Create Temporary Array 
            int[] lefttemp = new int[numbs.Length];
            // shift numbers from the left.
            lefttemp[0] = 1;

            for (int i = 1; i < numbs.Length ; i++)
            {
                lefttemp[i] = lefttemp[i-1]* numbs[i - 1];
            }

            // shift numbers from the right 
            int[] rightTemp = new int[numbs.Length];

            rightTemp[numbs.Length - 1] = 1;

            for (int i = numbs.Length-2; i >=0; i--)
            {
                rightTemp[i] = numbs[i + 1] * rightTemp[i +  1];
            }

            int[] result = new int[numbs.Length];
            for(int i=0;i<numbs.Length;i++)
            {
                result[i] = lefttemp[i] * rightTemp[i];
            }
            
        }

        static void SimpleVersion()
        {
            int[] numbs = new int[] { 1, 2, 3, 4 };
            int n = numbs.Length;
            // Create Temporary Array 
            int[] lefttemp = new int[n];
            // shift numbers from the left.
            lefttemp[0] = 1;

            for (int i = 1; i < n; i++)
            {
                lefttemp[i] = lefttemp[i - 1] * numbs[i - 1];
            }

            int right = 1;
            for( int i=n-1;i>=0;i--)
            {
                lefttemp[i] *= right;
                right *= numbs[i];
            }

        }
    }
}
