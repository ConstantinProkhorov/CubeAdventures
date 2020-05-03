using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private PlaySound PlaySound_ = null;
    void Start()
    {
        PlaySound_.Play();
    }
}
