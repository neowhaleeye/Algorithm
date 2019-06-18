using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Closest_Points_to_Origin
{
    class Program
    {
        static void Main(string[] args)

        {
            int[][] ay = new int[3][];
            ay[0] = new int[]{ 3,3};
            ay[1] = new int[] { 5, -1 };
            ay[2] = new int[] { -2, 4 };


            new Solution().KClosest(ay, 2);
        }
    }

    public class Solution
    {
        private Dictionary<int, double> distances = new Dictionary<int, double>();
        public int[][] KClosest(int[][] points, int K)
        {
            for(int i = 0; i < points.Length; i++)
            {
                int px = points[i][0];
                int py = points[i][1];
                double distance = GetDistance(px, py);
                distances.Add(i, distance);
            }

            var candidates = distances.OrderBy(e=>e.Value).Take(K);
            var result = new int[K][];
            int idx = 0;
            foreach (var c in candidates)
            {
                result[idx++] = new int[] { points[c.Key][0], points[c.Key][1] };               
            }

            return result;
        }

        private double GetDistance(int x, int y)
        {
            var r = x * x + y * y;
            return Math.Sqrt(r);
        }
    }
}
