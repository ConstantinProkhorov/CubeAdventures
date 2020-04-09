using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button Button;
    private int restartPrice;
    private string lastLevelName;
    private bool CanRestart = false;
    public void Start()
    {
        lastLevelName = SceneController.LastLevel;
        GameData.RestartLevelPrice.Get(lastLevelName, out restartPrice);
        if (restartPrice <= SceneController.Diamonds)
        {
            CanRestart = true;
            Button.interactable = true;
        }
    }
    public void RestartGameLevel()
    {       
        if (CanRestart)
        {
            //ох не так это должно быть как-то
            SceneController.Diamonds -= restartPrice;
            SceneLoadManager.SceneLoad(lastLevelName);
        }
    }
}
