// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using System.Linq;

Console.WriteLine("Hello, World!");

var a = Init_A();
Console.WriteLine(a.Decision(new GameInfo { StrategyList = GetJ() }));

DecisionMaker Init_A()
{
    return new DecisionMaker("A", where: x=>x.Owner=="A", sort: x=>x.Score);
}
static List<Strategy> GetJ()
{
    return new List<Strategy>
    {
        new Strategy {
        Owner = "A",
        Score = 10,
        Description = "A 選擇 坦承不諱",
        },

       new Strategy
       {
           Owner = "A",
           Score = 5,
           Description = "A 選擇 閉口不言"
       }
    };
}
