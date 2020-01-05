// Обрабатывает переход на игровой уровень из StartScene
public class TapToPlay : BaseController
{
    private const string gameLevel = "GameLevel 1";
    void OnMouseDown()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            SceneLoad(gameLevel);
        }
    }
}