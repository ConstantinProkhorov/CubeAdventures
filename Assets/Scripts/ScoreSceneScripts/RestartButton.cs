public class RestartButton : BaseController
{
    public void SceneRestart(bool b)
    {
        if (b) SceneLoad(SceneController.LastLevel);
    }
    public void HomeSceneLoad(bool b)
    {
        if (b) SceneLoad("SelectLevel");
    }
}
