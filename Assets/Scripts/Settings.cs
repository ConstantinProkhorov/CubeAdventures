using UnityEngine;

public class Settings : MonoBehaviour
{
    /// <summary>
    /// Returns true if player disabled music on settings scene
    /// </summary>
    public static bool IsMusicMuted { get; private set; }
    /// <summary>
    /// Returns true if player disabled sounds on settings scene
    /// </summary>
    public static bool IsSoundsMuted { get; private set; }
    private void Start() => UpdateSettings();
    private void UpdateSettings()
    {
        if (PlayerPrefs.HasKey("IsMusicMuted"))
        {
            IsMusicMuted = PlayerPrefs.GetInt("IsMusicMuted") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("IsSoundsMuted"))
        {
            IsSoundsMuted = PlayerPrefs.GetInt("IsSoundsMuted") == 1 ? true : false;
        }
    }
    public void MuteMusic(bool mute)
    {
        PlayerPrefs.SetInt("IsMusicMuted", mute ? 1 : 0);
        UpdateSettings();
        // эта строчка тут вообще нужна?
        PlayerPrefs.Save();
    }
    public void MuteSounds(bool mute)
    {
        PlayerPrefs.SetInt("IsSoundsMuted", IsSoundsMuted ? 1 : 0);
        UpdateSettings();
        PlayerPrefs.Save();
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("IsMusicMuted", IsMusicMuted ? 1 : 0);
        PlayerPrefs.SetInt("IsSoundsMuted", IsSoundsMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
