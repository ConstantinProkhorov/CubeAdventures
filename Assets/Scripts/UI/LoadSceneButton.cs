using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Loads Target Scene. Method is called through inspector.
/// </summary>
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] string TargetSceneName = "StartScene";
    public void LoadScene() => SceneLoadManager.SceneLoad(TargetSceneName);
}
