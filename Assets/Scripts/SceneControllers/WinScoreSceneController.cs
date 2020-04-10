using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScoreSceneController : MonoBehaviour
{
    [SerializeField] private Text TotalWavesDisplay;
    //public Text HardestWaveDoneDisplay;
    [SerializeField] private Text ScoreGainedDisplay;
    [SerializeField] private Text DiamondsGainedDisplay;

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
