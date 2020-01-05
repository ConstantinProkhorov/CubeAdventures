using UnityEngine.UI;

public class EndScoreSceneController : BaseController 
{     
    private const byte buildIndex = 3;

    public Text scoreNumberDisplay;
    public Text diamondsNumberDisplay;

    public Text scoreSubstractedDisplay;
    public Text diamondsSubstractedDisplay;
    public Text PointsGainedOnLevel;

    void Start()
    {
        thisSetActive(buildIndex);      
        ScoreSubtraction();
        SubstractionInfoDisplay();
        ResultsDisplay();
    }
    private void ScoreSubtraction() // вычитание очков при проигрыше
    {
        int diamonds = SceneController.diamonds - ActiveLevelData.DiamondsSubtractAmount;
        SceneController.diamonds = diamonds < 0 ? 0 : diamonds;
    }
    private void SubstractionInfoDisplay()
    {
        scoreSubstractedDisplay.text = $"As a penalty {ActiveLevelData.PointsSubtractionAmount} points";
        diamondsSubstractedDisplay.text = $"and {ActiveLevelData.DiamondsSubtractAmount} diamonds were subtracted.";
        PointsGainedOnLevel.text = SceneController.ScoreGainedOnLevel.ToString();
    }
    private void ResultsDisplay()
    {
        scoreNumberDisplay.text = SceneController.score.ToString();
        diamondsNumberDisplay.text = SceneController.diamonds.ToString();
    }
}
