using System.Collections.Generic;

public class LevelRestartPrice : IStaticDataContainer
{
    private static Dictionary<string, int> RestartPrice = new Dictionary<string, int>
    {
        { "GameLevel 1",    0 },//стартовый уровень, поэтому 0
        { "GameLevel 2",    1 },//сюда очень легко попасть
        { "GameLevel 3",    2 },//близко к бонусному
        { "GameLevel 4",    2 },
        { "GameLevel 5",    0 },//bonus level, cant lose
        { "GameLevel 6",    2 },//новая базовая стоимость
        { "GameLevel 7",    2 },
        { "GameLevel 8",    2 },
        { "GameLevel 9",    3 },//игрок зашел далеко
        { "GameLevel 10",   3 },
        { "GameLevel 11",   5 },//близко к бонусному
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
