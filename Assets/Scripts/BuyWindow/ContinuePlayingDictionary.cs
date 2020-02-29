using System.Collections.Generic;
// цена продолжения игры в уровень
public class ContinuePlayingDictionary : IPriceDictionary
{
    private static Dictionary<string, int> LevelPrice = new Dictionary<string, int>
    {
        { "GameLevel 1", 1 },
        { "GameLevel 2", 2 },
        { "GameLevel 3", 4 },
        { "GameLevel 4", 8 },
        { "GameLevel 5", 8 },
        { "GameLevel 6", 8 },
        { "GameLevel 7", 8 },
        { "GameLevel 8", 8 },
        { "GameLevel 9", 8 },
        { "GameLevel 10", 8 },
        { "GameLevel 11", 8 },
        { "GameLevel 12", 8 },
        { "TestLevel", 0 },
        { "GameLevel 13", 8 }

    };

    public int GetPrice(string Name) // возвращает цену продолжения игры
    {
        return LevelPrice[Name];
    }
}
