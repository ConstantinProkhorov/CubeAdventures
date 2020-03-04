using UnityEngine;
public class RestartButton : MonoBehaviour
{
    public void SceneRestart(bool b)
    {
        if (b) SceneLoadManager.SceneLoad(SceneController.LastLevel);
    }
    public void HomeSceneLoad(bool b)
    {
        if (b) SceneLoadManager.SceneLoad("SelectLevel");
    }
}
