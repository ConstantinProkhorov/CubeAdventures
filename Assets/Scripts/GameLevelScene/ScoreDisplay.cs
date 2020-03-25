using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    //TODO: переписать через события
    public Text scoreDisplay;
    public GameLevelSceneController thisSceneController;
    void Update()
    {
        scoreDisplay.text = $"+{thisSceneController.ScoreGainedOnLevel}";
    }
}
