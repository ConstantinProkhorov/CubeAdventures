using UnityEngine;
/// <summary>
/// Checks wether sounds are muted before playing sound;
/// </summary>
public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource Sound;
    /// <summary>
    /// Plays sounds if sounds are not muted on the settings scene.
    /// </summary>
    /// <param name="IsSoundsOn"></param>
    public void Play()
    {
        if (Settings.IsSoundsOn)
        {
            Sound.Play();
        }
    }
}
