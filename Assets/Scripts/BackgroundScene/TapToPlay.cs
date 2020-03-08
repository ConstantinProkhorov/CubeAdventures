// Обрабатывает переход на игровой уровень из StartScene
using UnityEngine;
public class TapToPlay : MonoBehaviour
{
    private const string GameLevel = "GameLevel 1";
    void OnMouseDown()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            SceneLoadManager.SceneLoad(GameLevel);
        }
    }
}