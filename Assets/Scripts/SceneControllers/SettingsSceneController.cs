using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsSceneController : MonoBehaviour
{  
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
    }
    public void Reset() // временный метод для сброса настроек.
    {
        GameObject temp = GameObject.Find("MainScriptHolder");
        temp.GetComponent<SceneController>().PlayerDataReset();
    }
}
