using UnityEngine;

public class DelayedBehaviourActivation : MonoBehaviour
{   [Header("Activates Behaviour with Delay in seconds")]
    [SerializeField] private Behaviour Behaviour = null;
    // значение отсрочки в секундах
    [SerializeField] private float Delay = 2.0f;
    void Start()
    {
        Invoke(nameof(DelayedActivation), Delay);
    }
    private void DelayedActivation() => Behaviour.enabled = true;
}
