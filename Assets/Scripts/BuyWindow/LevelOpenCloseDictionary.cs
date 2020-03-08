using System.Collections.Generic;
public class LevelOpenCloseDictionary : IOpenCloseDictionary
{
    private static Dictionary<string, bool> LevelState = new Dictionary<string, bool>
    {
        { "GameLevel 1", true },
        { "GameLevel 4", true },
        { "GameLevel 7", true },
        { "GameLevel 8", true },
        { "GameLevel 10", true },
        { "GameLevel 11", true },
        { "GameLevel 12", true },
        { "TestLevel", true },
        { "GameLevel 13", true }
    };
    public bool GetState(string Name)
    {
        return LevelState[Name];
    }
    public void ChangeState(string Name) 
    {
        LevelState[Name] = true;
    }

    public static bool[] GetAllStates()
    {
        bool[] dictionary = new bool[LevelState.Values.Count];
        LevelState.Values.CopyTo(dictionary, 0);
        return dictionary;
    }

    public void SetAllStates(bool[] levelsState) //TODO: так, без конкатинации строк уже лучше, но всё равно какая-то дрянь.
    {
        string[] levelNames = new string[LevelState.Count];
        LevelState.Keys.CopyTo(levelNames, 0);
        for (int i = 0; i < LevelState.Count; i++)
        {
            LevelState[levelNames[i]] = levelsState[i];
        }
    }
}
