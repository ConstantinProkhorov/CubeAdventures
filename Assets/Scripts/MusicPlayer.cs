using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Логика проигрывания фоновой музыки при переключении между сценами
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private float FadeDuration = 2.0f;
    [SerializeField] private float FadeTargetVolume = 0.0f;
    [SerializeField] private AudioSource MenuMusic;
    [SerializeField] private AudioSource GameLevelMusic;
    void Start()
    {
        SceneLoadManager.NewSceneLoaded += (int currentActiveScent, int sceneToBeLoaded) =>
        {
            //загрузка игровой сцены после сцены меню
            if (IsGameLevel(sceneToBeLoaded))
            {
                StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
                GameLevelMusic.Play();
            }
            //загрузка сценю меню после игровой сцены
            else if (IsGameLevel(currentActiveScent))
            {
                StartCoroutine(FadeAudioSource.StartFade(GameLevelMusic, FadeDuration, FadeTargetVolume));
                MenuMusic.Play();
            }
        };
    }
    /// <summary>
    /// Incapsulates logic for determening wether the scene is GameLevel Scene.
    /// Return true if it is.
    /// </summary>
    private bool IsGameLevel(int sceneIndex) 
    {
        return SceneManager.GetSceneByBuildIndex(sceneIndex).name.Contains("Game");
    }
}
