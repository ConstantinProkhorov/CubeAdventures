using System.Collections.Generic;
// цена открытия игровых уровней
public class LevelOpenPriceDictionary : IPriceDictionary
{
    private static Dictionary<string, int> LevelPrice = new Dictionary<string, int>
    {
        { "GameLevel 1", 0 },
        { "GameLevel 4", 0 },
        { "GameLevel 7", 0 },
        { "GameLevel 8", 0 },
        { "GameLevel 10", 0 },
        { "GameLevel 11", 0 },
        { "GameLevel 12", 0 },
        { "TestLevel", 0 },
        { "GameLevel 13", 0 }
    };

    public int GetPrice(string Name) // возвращает цену разблокировки
    {
        return LevelPrice[Name];
    }
}
