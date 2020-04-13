using System.Collections.Generic;

public class WavesNamesDictionary : IStaticDataContainer
{
    private static Dictionary<string, string> WaveName = new Dictionary<string, string>
    {
        { "GameLevel 1",    "Omega Wave" },
        { "GameLevel 2",    "UntitledWave" },
        { "GameLevel 3",    "UntitledWave" },
        { "GameLevel 4",    "UntitledWave" },
        { "GameLevel 5",    "UntitledWave" },
        { "GameLevel 6",    "UntitledWave" },
        { "GameLevel 7",    "UntitledWave" },
        { "GameLevel 8",    "UntitledWave" },
        { "GameLevel 9",    "UntitledWave" },
        { "GameLevel 10",   "UntitledWave" },
        { "GameLevel 11",   "UntitledWave" },
        { "GameLevel 12",   "UntitledWave" },
        { "TestLevel",      "This is Test Level" }
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
