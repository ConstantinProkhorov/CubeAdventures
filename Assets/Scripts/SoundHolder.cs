using UnityEngine;

public class SoundHolder : MonoBehaviour
{
    [SerializeField] private AudioSource CoinSound;
    public void PlayCoinSound() => CoinSound.Play();
}
