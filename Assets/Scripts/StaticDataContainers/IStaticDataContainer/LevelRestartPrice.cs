using System.Collections.Generic;

public class LevelRestartPrice : IStaticDataContainer
{
    private static Dictionary<string, int> RestartPrice = new Dictionary<string, int>
    {
        { "GameLevel 1",    1 },//стартовый уровень, поэтому 1
        { "GameLevel 2",    1 },//сюда очень легко попасть
        { "GameLevel 3",    2 },
        { "GameLevel 4",    2 },
        { "GameLevel 5",    3 },//близко к бонусному
        { "GameLevel 6",    0 },//bonus level, cant lose
        { "GameLevel 7",    2 },
        { "GameLevel 8",    2 },
        { "GameLevel 9",    2 },
        { "GameLevel 10",   2 },
        { "GameLevel 11",   2 },
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
