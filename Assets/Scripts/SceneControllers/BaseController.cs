using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    public void thisSetActive(int index)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
    }

    protected void LoadMenuScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }

    public void SceneLoad(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SaveFileManager.Save(new PlayerData(SceneController.score, SceneController.diamonds, SceneController.lastForm, 
            SceneController.r, SceneController.g, SceneController.b, SceneController.LastLevel, LevelOpenCloseDictionary.GetAllStates(), СolorOpenCloseDictionary.GetAllStates()));
        SceneManager.UnloadSceneAsync(activeScene.buildIndex);

        PauseButton pauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();//TODO: подумать над способами избавиться от операции Find()
        pauseButton.PauseEventToNull();
        pauseButton.blurTransparencyChange.ResetColor();
        pauseButton.ScreenBlur.SetActive(false);
        PauseButton.PauseClick = false;        // убирает меню  
        Time.timeScale = 1;                    // восстанавливаем ход времени
        AndroidControlls.GameIsPaused = false; // разблокируем управление    

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);                 
    }
}
