using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScoreSceneController : MonoBehaviour
{     
    [SerializeField] private Text ScoreGainedDisplay;
    [SerializeField] private Text DiamondsGainedDisplay;
    [SerializeField] private Text DiamondsNeededToRestart;
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
