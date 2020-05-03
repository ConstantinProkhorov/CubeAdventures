using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private PlaySound PlaySound_;
    void Start()
    {
        PlaySound_.Play();
    }
}
