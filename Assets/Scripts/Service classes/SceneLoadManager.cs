using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{
    /// <summary>
    /// BuildIndex of current active scene.
    /// </summary>
    public static int ActiveSceneIndex { get; private set; } = 1;
    /// <summary>
    /// Name of current active scene.
    /// </summary>
    //TODO: оптимизировать обращение. Надо, чтобы был закрый сеттер переустонавливающий значение при загрузке сцены.
    public static string ActiveSceneName { get => (SceneManager.GetSceneByBuildIndex(ActiveSceneIndex).name); }
    /// <summary>
    /// Fired when new Scene is loaded. Has current active scene name and scene to be loaded name as params.
    /// </summary>
    public static event Action<string, string> NewSceneLoaded;
    /// <summary>
    /// Provides logic for correct additive scene load within this project. Use it insted of SceneManager.LoadScene().
    /// </summary>
    /// <param name="sceneToLoadName">Name of the scene to load</param>
    public static void SceneLoad(string sceneToLoadName)
    {
        //TODO: выставление загруженной сцены активной должно быть здесь
        Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex; 
        //SaveFileManager.Save(new PlayerData(SceneController.CurrentSessionPlayerData));
        SceneManager.UnloadSceneAsync(activeSceneIndex);
        PauseButton pauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();//TODO: подумать над способами избавиться от операции Find()
        pauseButton.PauseEventToNull();
        pauseButton.blurTransparencyChange.ResetColor();
        pauseButton.ScreenBlur.SetActive(false);
        PauseButton.PauseClick = false;        // убирает меню  
        Time.timeScale = 1;                    // восстанавливаем ход времени
        AndroidControlls.GameIsPaused = false; // разблокируем управление    
        SceneManager.LoadScene(sceneToLoadName, LoadSceneMode.Additive);
        ActiveSceneIndex = SceneManager.GetSceneByName(sceneToLoadName).buildIndex;
        NewSceneLoaded(activeScene.name, sceneToLoadName);
    }
}
