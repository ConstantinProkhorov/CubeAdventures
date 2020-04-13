using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsSceneController : MonoBehaviour
{
    [SerializeField] private SwitchButton MusicSwitch;
    [SerializeField] private SwitchButton SoundsSwitch;
    private GameObject MainScriptHolder;
    private Settings Settings;
    private MusicPlayer MusicPlayer;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        MainScriptHolder = GameObject.Find("MainScriptHolder");
        Settings = MainScriptHolder.GetComponent<Settings>();
        //выставление переключателей в начальное положение
        MusicSwitch.SetSwitchState(Settings.IsMusicOn);
        SoundsSwitch.SetSwitchState(Settings.IsSoundsOn);
        MusicPlayer = MainScriptHolder.GetComponent<MusicPlayer>();
    }
    public void Reset() // временный метод для сброса настроек.
    {
        MainScriptHolder.GetComponent<SceneController>().PlayerDataReset();
    }
    public void MuteMusic()
    {
        Settings.SetMusicState(!Settings.IsMusicOn); 
        MusicPlayer.PlayMenuMusic();
    }
    public void MuteSounds() => Settings.SetSoundsState(!Settings.IsSoundsOn);
}
