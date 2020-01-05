using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;
    public LevelSceneController thisSceneController;
    private string TotalScore;

    void Start()
    {
        TotalScore = SceneController.score.ToString();
    }
    void Update()
    {
        scoreDisplay.text = $"{TotalScore} (+{thisSceneController.ScoreGainedOnLevel})";
    }
}
