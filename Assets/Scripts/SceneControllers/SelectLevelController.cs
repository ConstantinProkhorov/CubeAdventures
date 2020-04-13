using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevelController : MonoBehaviour
{
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
    }
}
