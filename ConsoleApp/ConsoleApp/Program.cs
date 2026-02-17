// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using System.Linq;

Console.WriteLine("Hello, World!");

var a = Init_A_When_B_Is_Deny();
Console.WriteLine(a.Decision(new GameInfo { StrategyList = GetJ() }));

DecisionMaker Init_A_When_B_Is_Deny()
{
    return new DecisionMaker("A"
        , where: x => x.Key.Actions[1] == "Deny"
        , sort: x => x.Value.Scores[0]
        , display: x=> x.Scores[0].ToString());
}
static Dictionary<ActionProfile, PayoffVector> GetJ()
{
    return new Dictionary<ActionProfile, PayoffVector>
    {
        { new ActionProfile("Admin", "Admin"), new PayoffVector(5, 5) },
        {new   ActionProfile("Admin", "Deny"), new PayoffVector(20, 0) },
        {new   ActionProfile("Deny", "Admin"), new PayoffVector(0, 20) },
        {new   ActionProfile("Deny", "Deny"), new PayoffVector(10, 10) },
    };
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