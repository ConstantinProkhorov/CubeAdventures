using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private ButtonSound PlaySound_ = null;
    void Start()
    {
        PlaySound_.Play();
    }
}
