using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{
    public static void SceneLoad(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SaveFileManager.Save(new PlayerData(SceneController.CurrentSessionPlayerData));
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
