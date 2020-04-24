[System.Serializable]
public class PlayerData 
{
    public int TotalWavesCleared;
    public string CurrentWaveName;
    public int TotalScore;
    public int Diamonds;
    public int Dynamite;
    public string LastForm;
    public float r, g, b;
    public string lastLevelPlayed = "GameLevel 1";
    public int[] avaliableFigures;

    public bool[] levelOpenCloseDictionary;
    public bool[] colorOpenCloseDictionary;
    public PlayerData()
    {
        CurrentWaveName = "ALFA Wave";
        TotalWavesCleared = 0;
        TotalScore = 5000;
        Diamonds = 100;
        Dynamite = 100;
        LastForm = "Forms/Sphere";
        r = 0.007843138f;
        g = 0.6784314f;
        b = 0.07843138f;
        lastLevelPlayed = "GameLevel 1";
        levelOpenCloseDictionary = new bool[] { true, false, false, false };
        colorOpenCloseDictionary = new bool[] { true, true, false, false, false, false };
    }
    public PlayerData(PlayerData currentState)
    {
        TotalWavesCleared = currentState.TotalWavesCleared;
        CurrentWaveName = currentState.CurrentWaveName;
        TotalScore = currentState.TotalScore;
        LastForm = currentState.LastForm;
        Diamonds = currentState.Diamonds;
        Dynamite = currentState.Dynamite;
        r = currentState.r;
        g = currentState.g;
        b = currentState.b;
        lastLevelPlayed = currentState.lastLevelPlayed;
        levelOpenCloseDictionary = LevelOpenCloseDictionary.GetAllStates();
        colorOpenCloseDictionary = СolorOpenCloseDictionary.GetAllStates();
    }
}

