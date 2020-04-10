using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button Button;
    private int restartPrice;
    private string lastLevelName;
    public void Start()
    {
        lastLevelName = SceneController.LastLevel;
        GameData.RestartLevelPrice.Get(lastLevelName, out restartPrice);
        if (restartPrice <= SceneController.Diamonds)
        {
            Button.interactable = true;
        }
    }
    public void RestartGameLevel()
    {       
        SceneController.Diamonds -= restartPrice;
        SceneLoadManager.SceneLoad(lastLevelName);
    }
}
