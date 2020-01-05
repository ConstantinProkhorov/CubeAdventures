using System.Collections.Generic;
// цена открытия игровых уровней
public class LevelOpenPriceDictionary : IPriceDictionary
{
    private static Dictionary<string, int> LevelPrice = new Dictionary<string, int>
    {
        //{ "GameLevel 1", 0 },
        { "GameLevel 2", 10 },
        { "GameLevel 3", 20 },
        { "GameLevel 4", 40 }
    };

    public int GetPrice(string Name) // возвращает цену разблокировки
    {
        return LevelPrice[Name];
    }
}
