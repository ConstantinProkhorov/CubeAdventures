public class ScoreGainedOnLevel
{
    public int Score { get; private set; } = 0;
    public void Add(int amount = 10) => Score += amount;
    public void SaveScore()
    {
        SceneController.ScoreGainedOnLevel = Score;
        // уместна ли здесь эта проверка? Ведь у меня же нет условий при которых очки могут быть меньше нуля. На будущее? Кек...
        int scoreAfterSave = SceneController.Score += Score;
        SceneController.Score = scoreAfterSave >= 0 ? scoreAfterSave : 0;
    }
    public override string ToString() => Score.ToString();
}
