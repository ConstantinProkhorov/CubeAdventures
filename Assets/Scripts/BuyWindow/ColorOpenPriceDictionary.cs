using System.Collections.Generic;
// цена открытия цветов
public class ColorOpenPriceDictionary : IPriceDictionary
{
    private static Dictionary<string, int> ColorPrice = new Dictionary<string, int>
    {
        { "RedColor", 0 },
        { "GreenColor", 0 },
        { "BlueColor", 10 },
        { "PurpleColor", 20 },
        { "OrangeColor", 40 },
        { "GoldColor", 80 }
    };

    public int GetPrice(string Name) // возвращает цену разблокировки
    {
        return ColorPrice[Name];
    }
}
