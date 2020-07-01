using System.Collections.Generic;

public class LevelRestartPrice : IStaticDataContainer
{
    private static Dictionary<string, int> RestartPrice = new Dictionary<string, int>
    {
        { "GameLevel 1",    0 },
        { "GameLevel 2",    1 },
        { "GameLevel 3",    1 },
        { "GameLevel 4",    1 },//близко к бонусному
        { "GameLevel 5",    0 },//bonus level, cant lose
        { "GameLevel 6",    1 },
        { "GameLevel 7",    1 },
        { "GameLevel 8",    1 },
        { "GameLevel 9",    2 },
        { "GameLevel 10",   2 },
        { "GameLevel 11",   3 },//близко к бонусному
        { "GameLevel 12",   0 },//bonus level, cant lose
        { "GameTestLevel",      0 }
    };
    string IStaticDataContainer.Get(string dataName)
    {
        return RestartPrice[dataName].ToString();
    }
    string IStaticDataContainer.Get(string dataName, out int result)
    {
        result = RestartPrice[dataName];
        return result.ToString();       
    }
}
