using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] loc = new int[,] { { 1, 2 },{ 3, 4 },{ 1, -1 } };

            nearestXsteakHouses(3, loc, 2);
        }

        public static List<List<int>> nearestXsteakHouses(int totalSteakhouses,
                                           int[,] allLocations,
                                           int numSteakhouses)
        {
            


            Dictionary<int, int> valueContainer = new Dictionary<int, int>();

            
            for (int i = 0; i < allLocations.GetLength(0);i++)
            {
                for (int j=0;j<allLocations.GetLength(1);j++)
                {
                    int pointValue = allLocations[i, j];
                    int poweredValue = pointValue * pointValue;

                    if (valueContainer.Any(e => e.Key == i))
                    {
                        valueContainer[i] = valueContainer[i] + poweredValue;
                    }
                    else
                    {
                        valueContainer.Add(i, poweredValue);
                    }
                }
            }

            var sortedList = valueContainer.OrderBy(e => e.Value).Take(numSteakhouses);

            List<List<int>> result = new List<List<int>>();
            foreach (var v in sortedList)
            {
                List<int> pairs = new List<int>();
                pairs.Add(allLocations[v.Key, 0]);
                pairs.Add(allLocations[v.Key, 1]);
                result.Add(pairs);
            }

            return result;
            
        }
    }
}
