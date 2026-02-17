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
        public string Name { get; set; }
        Func<GameInfo, Dictionary<string, object>>  _evaluate;
        public DecisionMaker(string name, Func<GameInfo, Dictionary<string, object>> evaluate)
        {
            this.Name = name;
            this._evaluate = evaluate;
        }

        public Dictionary<string, object> Decision(GameInfo info) {
            return _evaluate(info);
        }
    }

    public class GameInfo
    {
        public List<object> Json { get; set; } 
    }

}
