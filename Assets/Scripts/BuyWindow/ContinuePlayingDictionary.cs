using System.Collections.Generic;
// цена продолжения игры в уровень
public class ContinuePlayingDictionary : IPriceDictionary
{
    private static Dictionary<string, int> LevelPrice = new Dictionary<string, int>
    {
        { "GameLevel 1", 1 },
        { "GameLevel 2", 2 },
        { "GameLevel 3", 4 },
        { "GameLevel 4", 8 }
    };

    public int GetPrice(string Name) // возвращает цену продолжения игры
    {
        return LevelPrice[Name];
    }
}
