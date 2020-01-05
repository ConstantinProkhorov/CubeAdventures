using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNameDetectClicksTapToPlay : MonoBehaviour
{
    public GameObject TapToPlay;
    public GameObject DetectClicks;
    public GameObject GameName;
    public bool Menuloaded;

    void Update()
    {
        Scene Menu = SceneManager.GetSceneByBuildIndex(1);
        if (Menu.isLoaded)
        {
            Menuloaded = true;
        }
        else
        {
            Menuloaded = false;
        }

        if (Menuloaded == true)
        {
            TapToPlay.SetActive(true);
            DetectClicks.SetActive(true);
            GameName.SetActive(true);
        }

        else
        {
            TapToPlay.SetActive(false);
            DetectClicks.SetActive(false);
            GameName.SetActive(false);
        }
    }
}


