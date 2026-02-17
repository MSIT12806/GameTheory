// See https://aka.ms/new-console-template for more information

using ConsoleApp;

Console.WriteLine("Hello, World!");

var a = Init_A();
Console.WriteLine(ShowDecission(a.Decision(new GameInfo { Json = GetJ() })));

DecisionMaker Init_A()
{
    return new DecisionMaker("A", info =>
    {
        return info.Json.Cast<Dictionary<string, object>>().Where(x => x["object"] == "A").OrderByDescending(x => x["value"]).FirstOrDefault();
    });
}
string ShowDecission(Dictionary<string, object> result)
{
    return (result["value"]).ToString();
}
static List<object> GetJ()
{
    return  new List<object>
    {
        new Dictionary<string, object>
        {
            {"object", "A"},
            {"value", 10}
        },
        new Dictionary<string, object>
        {
            {"object", "A"},
            {"value", 5}
        },
    };
}
