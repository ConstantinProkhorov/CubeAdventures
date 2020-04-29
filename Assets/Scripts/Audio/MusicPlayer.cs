using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneLoadManager.NewSceneLoaded += (int currentActiveScene, int sceneToBeLoaded) =>
        {
            if (Settings.IsMusicOn)
            {
                //если загружаемая сцена игровая
                if (ListOfGameLevels.IsGameLevel(SceneManager.GetSceneByBuildIndex(sceneToBeLoaded).name))
                {
                    //и если выгружаемая сцена не содержится в заданном списке,  то включается GameLevelMusic
                    if (!ListOfScenesToPlayGameLevelMusic.Contains(SceneManager.GetSceneByBuildIndex(currentActiveScene).name))
                    {
                    StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
                    StartCoroutine(PlayAfterFade(GameLevelMusic));
                    }
                }
                //если выгружаемая сцена игровая
                else if (ListOfGameLevels.IsGameLevel(SceneManager.GetSceneByBuildIndex(currentActiveScene).name))
                {
                    //и если загружаемая сцена не содержится в заданном списке, то включается MenuMusic
                    if (!ListOfScenesToPlayGameLevelMusic.Contains(SceneManager.GetSceneByBuildIndex(sceneToBeLoaded).name))
                    {
                        StartCoroutine(FadeAudioSource.StartFade(GameLevelMusic, FadeDuration, FadeTargetVolume));
                        StartCoroutine(PlayAfterFade(MenuMusic));
                    }
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
    /// Plays given audioSource. FadeDuration should be equal to FadeAudioSource FadeDuration. 
    /// </summary>
    private IEnumerator PlayAfterFade(AudioSource audioSourceToPlay)
    {
        yield return new WaitForSecondsRealtime(FadeDuration);
        audioSourceToPlay.Play();
    }
}
