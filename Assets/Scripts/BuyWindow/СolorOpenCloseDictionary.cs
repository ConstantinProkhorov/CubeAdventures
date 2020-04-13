using System.Collections.Generic;

public class СolorOpenCloseDictionary : IOpenCloseDictionary
{
    private static Dictionary<string, bool> ColorState = new Dictionary<string, bool>
    {
        { "RedColor", true },
        { "GreenColor", true },
        { "BlueColor", false },
        { "PurpleColor", false },
        { "OrangeColor", false },
        { "GoldColor", false }
    };
    public bool GetState(string Name) 
    {
        return ColorState[Name];
    }
    public void ChangeState(string Name) 
    {
        ColorState[Name] = true;
    }
    public static bool[] GetAllStates()
    {
        bool[] dictionary = new bool[ColorState.Values.Count];
        ColorState.Values.CopyTo(dictionary, 0);
        return dictionary;
    }
    public void SetAllStates(bool[] States) //TODO: так, без конкатинации строк уже лучше, но всё равно какая-то дрянь.
    {
        string[] colorNames = new string[ColorState.Count];
        ColorState.Keys.CopyTo(colorNames, 0);
        for (int i = 0; i < ColorState.Count; i++)
        {
            ColorState[colorNames[i]] = States[i];
        }
    }
    /// <summary>
    /// Use with care. Resets all unlock progress.
    /// </summary>
    public void Reset()
    {
        SetAllStates(new bool[] { true, true, false, false, false, false });
    }
}
