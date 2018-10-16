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
            MyVersion();
            SimpleVersion();
            
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

            lefttemp.ToList().ForEach(e => Console.WriteLine(e));

        }

        static void MyVersion()
        {
            int[] numbs = new int[] { 1, 2, 3, 4 };
            int[,] matrix = new int[numbs.Length+1, numbs.Length];

            for(int i=0;i< numbs.Length;i++)
            {
                int rowSum = 1;
                for(int j=0;j<numbs.Length;j++)
                {
                    int val = 0;
                    if (i == j) val = 1;
                    else val = numbs[j];
                    rowSum *= val;
                    matrix[i, j] = val;
                }
                matrix[numbs.Length,i ] = rowSum;
            }

            for (int i=0;i<matrix.GetLength(1);i++)
            {
                numbs[i] = matrix[matrix.GetLength(0) - 1, i];
            }
            numbs.ToList().ForEach(e => Console.WriteLine(e));



        }
    }
}
