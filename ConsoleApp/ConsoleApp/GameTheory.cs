
using System.Linq;

namespace ConsoleApp
{
    public class GameTheory
    {
    }

    public class DecisionMaker
    {
        /*
         * 決策(Decision)可以被拆解為篩選、排序的這兩個行為的組合。
         */

        public  Func<KeyValuePair<ActionProfile, PayoffVector>, bool> Where;
        public  Func<KeyValuePair<ActionProfile, PayoffVector>, int> Sort;
        public Func<PayoffVector, string> Display;
        public string Name { get; set; }
        public DecisionMaker(string name,
            Func<KeyValuePair<ActionProfile, PayoffVector>, bool> where,
            Func<KeyValuePair<ActionProfile, PayoffVector>, int> sort,
            Func<PayoffVector, string> display)
        {
            this.Name = name;
            this.Where = where;
            this.Sort = sort;
            Display = display;
        }

        public object Decision(GameInfo info)
        {
            return Display(info.StrategyList.Where(x=>true).OrderByDescending(Sort).First().Value);
        }
    }

    public class GameInfo
    {
        public Dictionary<ActionProfile, PayoffVector> StrategyList { get; set; }
    }
    public record ActionProfile(params string[] Actions);
    public record PayoffVector(params int[] Scores);
}
