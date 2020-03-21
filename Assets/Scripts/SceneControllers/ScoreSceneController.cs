using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSceneController : MonoBehaviour
{
    public Text TotalWavesDisplay;
    //public Text HardestWaveDoneDisplay;
    public Text ScoreNumberDisplay;
    public Text DiamondsNumberDisplay;

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ResultsDisplay();
    }
    private void ResultsDisplay()
    {
        ScoreNumberDisplay.text = SceneController.Score.ToString();
        DiamondsNumberDisplay.text = SceneController.Diamonds.ToString();
        TotalWavesDisplay.text = SceneController.CurrentSessionPlayerData.TotalWavesCleared.ToString();
    }   
}
