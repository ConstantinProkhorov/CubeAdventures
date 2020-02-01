using System.Collections.Generic;
// цена открытия цветов
public class ColorOpenPriceDictionary : IPriceDictionary
{
    private static Dictionary<string, int> ColorPrice = new Dictionary<string, int>
    {
        //{ "RedColor", 10 },
        //{ "GreenColor", 10 },
        { "BlueColor", 1000 },
        { "PurpleColor", 2000 },
        { "OrangeColor", 4000 },
        { "GoldColor", 8000 }
    };

    public int GetPrice(string Name) // возвращает цену разблокировки
    {
        return ColorPrice[Name];
    }
}
