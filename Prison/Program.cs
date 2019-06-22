using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prison
{
    class Program
    {
        static void Main(string[] args)
        {

            new Solution().PrisonAfterNDays(new[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 16);
        }
    }

    public class Solution
    {
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            return Traverse(cells, 0, N);
        }

        private int[] Traverse(int[] cells, int repeating, int N)
        {
            Dictionary<string, int> key = new Dictionary<string, int>();

            int rowFound = 0;
            while (repeating < N)
            {
                if (key.ContainsKey(GenerateKey(cells)))
                {
                    break;
                    
                }
                else
                {
                    key.Add(GenerateKey(cells), repeating);
                }
                int[] newCell = new int[cells.Length];
                for (int i = 0; i < cells.Length; i++)
                {
                    if (i == 0 || i >= cells.Length - 1) continue;

                    if (cells[i - 1] == cells[i + 1]) newCell[i] = 1;
                }

                cells = newCell;
                
                repeating++;
            }

            int remain = N % key.Count;

            string k = key.Where(e => e.Value == remain).First().Key;


            var r = k.ToCharArray().Select(e=>Convert.ToInt32(e)).ToArray<int>();

            return cells;

        }

        private string GenerateKey(int[] cells)
        {
            StringBuilder strb = new StringBuilder();
            cells.ToList().ForEach(e => strb.Append(e));
            return strb.ToString();
        }
    }
}
