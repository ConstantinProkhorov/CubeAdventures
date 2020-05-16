using System.Collections.Generic;
/// <summary>
/// Dictionary with Color unlock prices.
/// </summary>
public class ColorOpenPriceDictionary : IPriceDictionary
{
    private static Dictionary<string, int> ColorPrice = new Dictionary<string, int>
    {
        { "RedColor", 0 },
        { "GreenColor", 0 },
        { "BlueColor", 2000 },
        { "PurpleColor", 3000 },
        { "OrangeColor", 6000 },
        { "GoldColor", 9000 }
    };
    /// <summary>
    /// Returns color unlock price.
    /// </summary>
    /// <param name="Name">Color name</param>
    public int GetPrice(string Name)
    {
        return ColorPrice[Name];
    }
}
