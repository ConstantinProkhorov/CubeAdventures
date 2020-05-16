using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScoreSceneController : MonoBehaviour
{
    [SerializeField] private Text TotalWavesDisplay = null;
    [SerializeField] private Text ScoreGainedDisplay = null;
    [SerializeField] private Text DiamondsGainedDisplay = null;

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ResultsDisplay();
    }
    private void ResultsDisplay()
    {
        ScoreGainedDisplay.text = $"+{SceneController.ScoreGainedOnLevel.ToString()}";
        DiamondsGainedDisplay.text = $"+{SceneController.DiamondsGainedOnLevel.ToString()}";
        TotalWavesDisplay.text = SceneController.CurrentSessionPlayerData.TotalWavesCleared.ToString();
    }   
}
