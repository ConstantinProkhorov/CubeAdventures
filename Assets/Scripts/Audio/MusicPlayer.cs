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
    /// <summary>
    /// Определяет какая музыка проигрывается на какой сцене. 
    /// Я изначально думал над созданием словаря с соответствиями. И хотя словари более очевидные, возникает проблема.
    /// Так как в игре уже очень много словарей, ссылающихся на имя сцены и любые изменения имен сцен и их добавление, 
    /// что наиболее важно, вызовет цепочку доработок, которая мне не нужна. Это решение страдает от той же проблему, но только частично. 
    /// </summary>
    private AudioSource GetAudioSourceForScene(string sceneName)
    {
        if (ListOfGameLevels.IsGameLevel(sceneName))
        {
            return GameLevelMusic;
        }
        else if (sceneName == "WinScore" | sceneName == "EndScore")
        {
            return GameLevelMusic;
        }
        else return MenuMusic;
    }
    void Start()
    {
        //проигрывание музыки при загрузке игры
        PlayMenuMusic();
        SceneLoadManager.NewSceneLoaded += (string currentActiveScene, string sceneToBeLoaded) =>
        {
            if (Settings.IsMusicOn)
            {
                AudioSource currentSceneMusic = GetAudioSourceForScene(currentActiveScene);
                AudioSource sceneToBeLoadedMusic = GetAudioSourceForScene(sceneToBeLoaded);
                //условие переключения музыки - музыка на сцена отличается
                if (currentSceneMusic != sceneToBeLoadedMusic)
                {
                    //если загружаемая сцена нужна GameLevelMusic 
                    if (sceneToBeLoadedMusic == GameLevelMusic)
                    {
                        StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
                        StartCoroutine(PlayAfterFade(GameLevelMusic));
                    }
                    //если загружаемой сцене нужна MenuMusic
                    else if (sceneToBeLoadedMusic == MenuMusic)
                    {
                        StartCoroutine(FadeAudioSource.StartFade(GameLevelMusic, FadeDuration, FadeTargetVolume));
                        StartCoroutine(PlayAfterFade(MenuMusic));
                    }
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
    }
    public void FadeMenuMusic()
    {
        StartCoroutine(FadeAudioSource.StartFade(MenuMusic, FadeDuration, FadeTargetVolume));
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
