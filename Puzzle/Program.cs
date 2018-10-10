using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //wagl
            //aglk
            //glkn
            //lkna
            //knag
            //naga
            //gawu
            string inputStr = "awaglknagawunagwkwag";
            //int length = 4;

           //List<string>= new System.Collections.Stack();
            List<string> result = new List<string>();
            List<string> final = new List<string>();

            StringBuilder strb = new StringBuilder();
            for(int i=0;i< inputStr.Length;i++)
            {
                int curcnt = 0;
                while(result.Count <4)
                {
                    int charIndex = i + curcnt++;
                    if(charIndex>=inputStr.Length)
                    {
                        break;
                    }
                    if (!result.Any(e=>e == inputStr[charIndex].ToString()))
                    {
                        result.Add(inputStr[charIndex].ToString());
                    }
                }


                result.ForEach(e => strb.Append(e));
                result.Clear();
                final.Add(strb.ToString());
                strb.Clear();
                //result.Add(strb.ToString());

            }

            

            final.ForEach(e => Console.WriteLine(e));
            


            //var grouped = inputStr.GroupBy(e => e).Select((e, i) => new { Index = i, Value = e.Key.ToString() });


            //var crossjoin = from g in grouped
            //                from gg in grouped
            //                where g.Index != gg.Index
            //                select new { Val = g.Value + gg.Value };


            //var distincted = crossjoin.Distinct().Select(e => new { Value = e.Val });

            //var c2 = from g in distincted
            //         from gg in distincted
            //         select new { Val = g.Value + gg.Value };

            //var final = c2.Distinct().Select(e => new { Value = e.Val });


            //foreach (var c in final)
            //{
            //    Console.WriteLine(c);
            //}

        }
    }
}
