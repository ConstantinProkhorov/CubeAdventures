using System;
public class ScoreGainedOnLevel
{
    public int Score { get; private set; } = 0;

    public void Add(int amount = 10)
    {
        Score += amount;
    }
    private void Substract()
    {
        Score -= ActiveLevelData.PointsSubtractionAmount;      
    }
    public void Reset(float timer) 
    {
        if (ActiveLevelData.TimerIsNeeded)
        {
            if (timer > 0) Score = 0;
            Save();
        }
        else Save();
    }
    [Obsolete("Was used for mechanic of points substraction. Use void SaveScore() instead.")]
    public void Save()
    {
        int temp = SceneController.score + Score;
        SceneController.score = temp < 0 ? 0 : temp;
        SceneController.ScoreGainedOnLevel = Score;
    }
    public void SaveScore()
    {
        SceneController.score += Score;
    } 
    public override string ToString()
    {
        return Score.ToString();
    }
}
