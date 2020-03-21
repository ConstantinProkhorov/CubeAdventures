using UnityEngine;
using UnityEngine.UI;
public class DynamiteDisplay : MonoBehaviour
{
    public Text DynamitesDisplay;
    public GameLevelSceneController thisSceneController;
    void FixedUpdate()
    {
        DynamitesDisplay.text = $"{SceneController.Dynamite.ToString()}";
    }
}
