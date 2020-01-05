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
    private void Save()
    {
        int temp = SceneController.score + Score;
        SceneController.score = temp < 0 ? 0 : temp;
        SceneController.ScoreGainedOnLevel = Score;
    }
    public override string ToString()
    {
        return Score.ToString();
    }
}
