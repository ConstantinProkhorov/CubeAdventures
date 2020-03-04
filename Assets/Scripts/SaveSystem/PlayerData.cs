﻿[System.Serializable]
public class PlayerData 
{
    public int TotalWavesCleared;
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
        TotalWavesCleared = 0;
        TotalScore = 0;
        Diamonds = 0;
        Dynamite = 100;
        LastForm = "Forms/Cube";
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
        LastForm = currentState.LastForm;
        Diamonds = currentState.Diamonds;
        Dynamite = currentState.Dynamite;
        r = currentState.r;
        g = currentState.g;
        b = currentState.b;
        lastLevelPlayed = currentState.lastLevelPlayed;
        levelOpenCloseDictionary = currentState.levelOpenCloseDictionary;
        colorOpenCloseDictionary = currentState.levelOpenCloseDictionary;
    }
}

