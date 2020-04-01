using UnityEngine;

public class LoadGameLevel : MonoBehaviour
{
    public void Click()
    { 
        SceneLoadManager.SceneLoad(SceneController.LastLevel);
    }
}
