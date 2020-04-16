using UnityEngine;
/// <summary>
/// Handles transition to GameLevelScene from WinScore scene on tap
/// </summary>
public class LoadNextGameLevel : MonoBehaviour
{
    //private ListOfGameLevels ListOfGameLevels = new ListOfGameLevels();
    public void LoadNext()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            string LastLevel = SceneController.LastLevel ?? "GameLevel 1";
            SceneLoadManager.SceneLoad(ListOfGameLevels.GetNextLevel(LastLevel));
        }
    }
}
