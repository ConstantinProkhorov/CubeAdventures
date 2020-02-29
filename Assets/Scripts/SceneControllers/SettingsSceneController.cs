using UnityEngine;
public class SettingsSceneController : BaseController
{
    private const byte buildIndex = 6;  
    void Start()
    {
        thisSetActive(buildIndex);
    }

    public void Reset() // временный метод для сброса настроек.
    {
        GameObject temp = GameObject.Find("MainScriptHolder");
        temp.GetComponent<SceneController>().PlayerDataReset();
    }
}
