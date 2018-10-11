using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x = new int[2][];
            x[0] = new int[3] { 1, 2, 3 };
            x[1] = new int[2] { 1, 2 };

            Console.WriteLine(x[0].Length);
            Console.WriteLine(x[1].Length);

            
            int[,] y = new int[3, 3] { { 0, 1, 2 }, { 0, 1, 2 }, { 0, 1, 2 } };



            Console.ReadKey();
        }
    }
}
