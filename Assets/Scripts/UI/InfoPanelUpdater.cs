using UnityEngine;
using UnityEngine.UI;

public class InfoPanelUpdater : MonoBehaviour
{
    [SerializeField] private Text ScoreDisplay;
    [SerializeField] private Text DiamondsDisplay;
    [SerializeField] private Text DynamiteDisplay;
    void FixedUpdate()
    {
        ScoreDisplay.text = SceneController.Score.ToString();
        DiamondsDisplay.text = SceneController.Diamonds.ToString();
        DynamiteDisplay.text = SceneController.Dynamite.ToString();
    }
}
