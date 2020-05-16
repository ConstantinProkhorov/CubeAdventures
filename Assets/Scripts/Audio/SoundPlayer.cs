using UnityEngine;
/// <summary>
/// SoundPlayer is a singleton.
/// </summary>
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource = null;
    /// <summary>
    /// SoundPlayer instance.
    /// </summary>
    public static SoundPlayer Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Plays sound if sounds are turned on.
    /// </summary>
    /// <param name="audioClip">Audio clip to play.</param>
    public void PlaySound(AudioClip audioClip)
    {
        if (Settings.IsSoundsOn)
        {
            AudioSource.clip = audioClip;
            AudioSource.Play();
        }
    }
}
