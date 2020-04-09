using System.Collections.Generic;

public class LevelRestartPrice : IStaticDataContainer
{
    private static Dictionary<string, int> RestartPrice = new Dictionary<string, int>
    {
        { "GameLevel 1",    1 },
        { "GameLevel 2",    1 },
        { "GameLevel 3",    1 },
        { "GameLevel 4",    1 },
        { "GameLevel 5",    1 },
        { "GameLevel 6",    1 },
        { "GameLevel 7",    1 },
        { "GameLevel 8",    1 },
        { "GameLevel 9",    1 },
        { "GameLevel 10",   1 },
        { "GameLevel 11",   1 },
        { "GameLevel 12",   1 },
        { "TestLevel",      0 }
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
