using UnityEngine;
/// <summary>
/// Handles transition to next GameLevelScene from WinScore scene.
/// </summary>
public class LoadNextGameLevel : MonoBehaviour
{
    public void LoadNext()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            string LastLevel = SceneController.LastLevel ?? "GameLevel 1";
            SceneLoadManager.SceneLoad(ListOfGameLevels.GetNextLevel(LastLevel));
        }
    }
}
