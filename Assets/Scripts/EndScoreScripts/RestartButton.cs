using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : BaseController
{
    public void SceneRestart(bool b)
    {
        if (b == true)
        {
            SceneLoad(SceneController.LastLevel);
        }
        }
    public void HomeSceneLoad(bool b)
    {
        if (b == true)
        {
            SceneLoad("SelectLevel");
        }
    }
}
