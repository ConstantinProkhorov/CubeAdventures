using System.Collections.Generic;

public class WavesNamesDictionary : IStaticDataContainer
{
    private static Dictionary<string, string> WaveName = new Dictionary<string, string>
    {
        { "GameLevel 1",    "Intruders" },
        { "GameLevel 2",    "Invaders" },
        { "GameLevel 3",    "Pitched Wave" },
        { "GameLevel 4",    "Splitters" },
        { "GameLevel 5",    "Bonus Wave" },
        { "GameLevel 6",    "Rotors" },
        { "GameLevel 7",    "Rain Wave" },
        { "GameLevel 8",    "Reapers" },
        { "GameLevel 9",    "Horde" },
        { "GameLevel 10",   "Dread Wave" },
        { "GameLevel 11",   "Nightmare Wave" },
        { "GameLevel 12",   "Prize Wave" },
        { "GameTestLevel",  "This is Test Level" }
    };
    string IStaticDataContainer.Get(string dataName)
    {
        return WaveName[dataName];
    }
    string IStaticDataContainer.Get(string dataName, out int result)
    {
        result = 0;
        return WaveName[dataName];       
    }
}
