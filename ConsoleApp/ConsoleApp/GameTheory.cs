using System;
using System.Collections.Generic;
using System.Text;

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

        public  Func<Strategy, bool> Where;
        public  Func<Strategy, int> Sort;
        public string Name { get; set; }
        public DecisionMaker(string name, Func<Strategy, bool> where, Func<Strategy, int> sort)
        {
            this.Name = name;
            this.Where = where;
            this.Sort = sort;
        }

        public Strategy Decision(GameInfo info)
        {
            return info.StrategyList.Where(Where).OrderByDescending(Sort).First();
        }
    }

    public class GameInfo
    {
        public List<Strategy> StrategyList { get; set; }
    }

    public record Strategy
    {
        public string Owner { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }

}
