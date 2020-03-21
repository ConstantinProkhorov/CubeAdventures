using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScoreSceneController : MonoBehaviour
{     
    public Text ScoreGainedDisplay;
    public Text DiamondsNumberDisplay;

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ResultsDisplay();
    }
    private void ResultsDisplay()
    {
        ScoreGainedDisplay.text = SceneController.ScoreGainedOnLevel.ToString();
        DiamondsNumberDisplay.text = SceneController.Diamonds.ToString();
    }
}
