// Handles transition to GameLevelScene from WinScore scene on tap
public class TapToContinue : BaseController
{
    void OnMouseDown()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            SceneLoad(SceneController.LastLevel ?? "GameLevel 1");
        }
    }
}
