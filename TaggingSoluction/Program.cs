using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggingSoluction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Return a list where the first elements is the start index, scond is end index
            //
            var targetList = new List<string> { "made", "in", "spain" };
            var tags = new List<string> { "made", "weather", "forecast", "says", "that", "made", "rain", "in", "spain", "stays" };

            var indexWithTags = tags.Select((e, i) => new { Index = i, Value = e });

            var v = from t in targetList
                    from tt in indexWithTags
                    where t == tt.Value
                    select tt;

            var vvv = v.GroupBy(e => e.Value).Select(e => new { Key = e.Key, Order = e.ToList().OrderByDescending(ee => ee.Index).FirstOrDefault().Index }).OrderBy(e => e.Order);

            Console.WriteLine(vvv.First().Order);
            Console.WriteLine(vvv.Last().Order);




        }
    }
}
