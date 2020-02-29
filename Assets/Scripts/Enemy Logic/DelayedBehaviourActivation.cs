using UnityEngine;
using System;

public class DelayedBehaviourActivation : MonoBehaviour
{
    // поведение, которое надо запустить с отсрочкой //
    [SerializeField] private Behaviour Behaviour;
    // значение отсрочки в секундах
    [SerializeField] private float DelayTime = 2.0f;
    // таймер
    [SerializeField] private TimeCounter TimeCounter;

    void Start()
    {
        TimeCounter.TimerFinshed += (object sender, EventArgs eventArgs) => Behaviour.enabled = true;
        TimeCounter.TurnOn(DelayTime);
    }
}
