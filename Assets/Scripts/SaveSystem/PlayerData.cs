[System.Serializable]
public class PlayerData 
{
    public int totalScore;
    public int diamonds;
    public string lastForm;
    public float r, g, b;
    public string lastLevelPlayed = "GameLevel 1";
    public int[] avaliableFigures;

    public bool[] levelOpenCloseDictionary;
    public bool[] colorOpenCloseDictionary;

    public PlayerData(int score, int _diamonds, string form, float _r, float _g, float _b, string lastLevel, bool[] levelState, bool[] colorState)
    {
        totalScore = score;
        lastForm = form;
        diamonds = _diamonds;
        r = _r;
        g = _g;
        b = _b;
        lastLevelPlayed = lastLevel;
        levelOpenCloseDictionary = levelState;
        colorOpenCloseDictionary = colorState;
    }
    public PlayerData() // конструктор по умолчанию
    {
        totalScore = 0;
        //lastForm = "Forms/CatPlayer";
        lastForm = "Forms/Cube";
        diamonds = 0;
        r = 0;
        g = 0;
        b = 0;
        lastLevelPlayed = "GameLevel 1";
        levelOpenCloseDictionary = new bool[] { true, false, false, false };
        colorOpenCloseDictionary = new bool[] { true, true, false, false, false, false };
    }
}

