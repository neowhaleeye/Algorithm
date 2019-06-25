using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cut_Off_Trees_for_Golf_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int> { 54581641, 64080174, 24346381, 69107959 });
            list.Add(new List<int> { 86374198, 61363882, 68783324, 79706116 });
            list.Add(new List<int> { 668150, 92178815, 89819108, 94701471 });
            list.Add(new List<int> { 83920491, 22724204, 46281641, 47531096 });
            list.Add(new List<int> { 89078499, 18904913, 25462145, 60813308 });

            
            new Solution().CutOffTree(list);


        }
    }

    public class Solution
    {
        int finalCount;
        public int CutOffTree(IList<IList<int>> forest)
        {
          

                Traverse(forest, 0, 0, 0, 0);
            bool uncut = forest.Any(e => e.Any(ee => ee != 0));

            if (uncut) return -1;

            return finalCount;

        }

        private void Traverse(IList<IList<int>> forest, int r, int c, int previousValue, int counted)
        {
            if (r < 0 || c < 0 || r >= forest.Count || c >= forest[0].Count || forest[r][c] == 0 || forest[r][c] < previousValue)
                return;

            int currentValue = forest[r][c];
            forest[r][c] = 1;
            finalCount = counted++;

            Traverse(forest, r - 1, c, currentValue, counted);
            Traverse(forest, r + 1, c, currentValue, counted);
            Traverse(forest, r , c-1, currentValue, counted);
            Traverse(forest, r , c+1, currentValue, counted);

        }
    }
}
