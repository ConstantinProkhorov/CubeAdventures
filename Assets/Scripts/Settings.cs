using UnityEngine;

public class Settings : MonoBehaviour
{
    /// <summary>
    /// Returns true if music is enabled on settings scene
    /// </summary>
    public static bool IsMusicOn { get; private set; } = true;
    /// <summary>
    /// Returns true if sounds are enabled on settings scene
    /// </summary>
    public static bool IsSoundsOn { get; private set; } = true;
    private void Start() => UpdateSettings();
    /// <summary>
    /// Set if the music is on or not.
    /// </summary>
    /// <param name="state">true == on, false == off</param>
    public void SetMusicState(bool state)
    {
        PlayerPrefs.SetInt("IsMusicOn", state ? 1 : 0);
        UpdateSettings();
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Set if the sounds is on or not.
    /// </summary>
    /// <param name="state">true == on, false == off</param>
    public void SetSoundsState(bool state)
    {
        PlayerPrefs.SetInt("IsSoundsOn", state ? 1 : 0);
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
