[System.Serializable]
public class PlayerData 
{
    public int TotalWavesCleared;
    public int TotalScore;
    public int Diamonds;
    public string lastForm;
    public float r, g, b;
    public string lastLevelPlayed = "GameLevel 1";
    public int[] avaliableFigures;

    public bool[] levelOpenCloseDictionary;
    public bool[] colorOpenCloseDictionary;
    public PlayerData()
    {
        TotalScore = 0;
        lastForm = "Forms/Cube";
        Diamonds = 0;
        r = 0;
        g = 0;
        b = 0;
        lastLevelPlayed = "GameLevel 1";
        levelOpenCloseDictionary = new bool[] { true, false, false, false };
        colorOpenCloseDictionary = new bool[] { true, true, false, false, false, false };
    }
    public PlayerData(PlayerData currentState)
    {
        TotalWavesCleared = currentState.TotalWavesCleared;
        TotalScore = currentState.TotalScore;
        lastForm = currentState.lastForm;
        Diamonds = currentState.Diamonds;
        r = currentState.r;
        g = currentState.g;
        b = currentState.b;
        lastLevelPlayed = currentState.lastLevelPlayed;
        levelOpenCloseDictionary = currentState.levelOpenCloseDictionary;
        colorOpenCloseDictionary = currentState.levelOpenCloseDictionary;
    }
}

