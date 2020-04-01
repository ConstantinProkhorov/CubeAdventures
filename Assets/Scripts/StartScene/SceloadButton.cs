using UnityEngine;

public class SceloadButton : MonoBehaviour
{
    [SerializeField] string TargetSceneName = "Store";
    public void Click()
    {
        SceneLoadManager.SceneLoad(TargetSceneName);
    }
}
