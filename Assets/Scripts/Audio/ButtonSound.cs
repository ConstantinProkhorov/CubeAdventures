using UnityEngine;
/// <summary>
/// Checks wether sounds are muted before playing sound;
/// </summary>
public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip ClickSound = null;
    /// <summary>
    /// Plays sounds if sounds are not muted on the settings scene.
    /// </summary>
    /// <param name="IsSoundsOn"></param>
    public void Play() => SoundPlayer.Instance.PlaySound(ClickSound);
}
