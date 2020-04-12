using UnityEngine;
/// <summary>
/// Логика проигрывания фоновой музыки
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private float FadeDuration = 2.0f;
    [SerializeField] private float FadeTargetVolume = 0.0f;
    [SerializeField] private AudioSource MenuMusic;
    [SerializeField] private AudioSource GameLevelMusic;
    void Start()
    {
        PlayMenuMusic();
        SceneLoadManager.NewSceneLoaded += (int currentActiveScent, int sceneToBeLoaded) =>
        {
            if (Settings.IsMusicOn)
            {
                //загрузка игровой сцены после сцены меню
                if (SceneLoadManager.IsGameLevel(sceneToBeLoaded))
                {
                    StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
                    GameLevelMusic.Play();
                }
                //загрузка сценю меню после игровой сцены
                else if (SceneLoadManager.IsGameLevel(currentActiveScent))
                {
                    PlayMenuMusic();          
                }
            }
        };
    }
    public void PlayMenuMusic()
    {
        if (Settings.IsMusicOn)
        {
            MenuMusic.Play();
        }
        else
        {
            StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
        }
    }
}
