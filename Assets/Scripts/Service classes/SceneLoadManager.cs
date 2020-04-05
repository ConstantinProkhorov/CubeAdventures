using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{
    /// <summary>
    /// Fired when new Scene is loaded. Has current active scene index and scene to be loaded index as params.
    /// </summary>
    public static event Action<int, int> NewSceneLoaded;
    /// <summary>
    /// Provides logic for correct additive scene load within this project. Use it insted of SceneManager.LoadScene().
    /// </summary>
    /// <param name="sceneName">Name of the scene to load</param>
    public static void SceneLoad(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex; 
        SaveFileManager.Save(new PlayerData(SceneController.CurrentSessionPlayerData));
        SceneManager.UnloadSceneAsync(activeSceneIndex);
        PauseButton pauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();//TODO: подумать над способами избавиться от операции Find()
        pauseButton.PauseEventToNull();
        pauseButton.blurTransparencyChange.ResetColor();
        pauseButton.ScreenBlur.SetActive(false);
        PauseButton.PauseClick = false;        // убирает меню  
        Time.timeScale = 1;                    // восстанавливаем ход времени
        AndroidControlls.GameIsPaused = false; // разблокируем управление    
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);                 
        NewSceneLoaded(activeScene.buildIndex, SceneManager.GetSceneByName(sceneName).buildIndex);
    }
}
