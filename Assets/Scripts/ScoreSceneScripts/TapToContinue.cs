using UnityEngine;
// Handles transition to GameLevelScene from WinScore scene on tap
public class TapToContinue : MonoBehaviour
{
    private ListOfGameLevels ListOfGameLevels = new ListOfGameLevels();
    void OnMouseDown()
    {
        if (!PauseButton.PauseClick) // блокировка при нажатой кнопке паузы (при открытом меню).
        {
            string LastLevel = SceneController.LastLevel ?? "GameLevel 1";
            SceneLoadManager.SceneLoad(ListOfGameLevels.GetNextLevel(LastLevel));
        }
    }
}
