using System.Collections;
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
                    StartCoroutine(PlayAfterFade(GameLevelMusic));
                }
                //загрузка сценю меню после игровой сцены
                else if (SceneLoadManager.IsGameLevel(currentActiveScent))
                {
                    StartCoroutine(FadeAudioSource.StartFade(GameLevelMusic, FadeDuration, FadeTargetVolume));
                    StartCoroutine(PlayAfterFade(MenuMusic));
                }
            }
        };
    } 
    // я пока оставляю это так. но тут проблема. Так как этот метод вызывается на старте, то при выключенных звуках все равно идет какой-то звук,
    // так  как срабатывает Fade
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
    /// <summary>
    /// Plays given audioSource. FadeDuration should be equale to FadeAudioSource FadeDuration. 
    /// </summary>
    private IEnumerator PlayAfterFade(AudioSource audioSourceToPlay)
    {
        yield return new WaitForSecondsRealtime(FadeDuration);
        audioSourceToPlay.Play();
    }
}
