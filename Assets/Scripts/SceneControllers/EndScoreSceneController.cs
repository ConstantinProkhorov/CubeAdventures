using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScoreSceneController : MonoBehaviour
{     
    public Text ScoreGainedDisplay;
    public Text DiamondsGainedDisplay;
    public Text DiamondsNeededToRestart;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ResultsDisplay();
    }
    private void ResultsDisplay()
    {
        ScoreGainedDisplay.text = $"+{SceneController.ScoreGainedOnLevel.ToString()}";
        DiamondsGainedDisplay.text = $"+{SceneController.DiamondsGainedOnLevel.ToString()}";
        DiamondsNeededToRestart.text = $"-{GameData.RestartLevelPrice.Get(SceneController.LastLevel)}";
    }
}
