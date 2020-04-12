using UnityEngine;

public class Settings : MonoBehaviour
{
    /// <summary>
    /// Returns true if player disabled music on settings scene
    /// </summary>
    public static bool IsMusicOn { get; private set; }
    /// <summary>
    /// Returns true if player disabled sounds on settings scene
    /// </summary>
    public static bool IsSoundsOn { get; private set; }
    private void Start() => UpdateSettings();
    public void MuteMusic(bool mute)
    {
        PlayerPrefs.SetInt("IsMusicOn", mute ? 1 : 0);
        UpdateSettings();
        PlayerPrefs.Save();
    }
    public void MuteSounds(bool mute)
    {
        PlayerPrefs.SetInt("IsSoundsOn", mute ? 1 : 0);
        UpdateSettings();
        PlayerPrefs.Save();
    }
    private void UpdateSettings()
    {
        if (PlayerPrefs.HasKey("IsMusicOn"))
        {
            IsMusicOn = PlayerPrefs.GetInt("IsMusicOn") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("IsSoundsOn"))
        {
            IsSoundsOn = PlayerPrefs.GetInt("IsSoundsOn") == 1 ? true : false;
        }
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("IsMusicOn", IsMusicOn ? 1 : 0);
        PlayerPrefs.SetInt("IsSoundsOn", IsSoundsOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
