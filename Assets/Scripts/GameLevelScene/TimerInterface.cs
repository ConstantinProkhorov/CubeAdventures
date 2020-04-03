using System;
using UnityEngine;
/// <summary>
/// Интерфейс для типов таймера.
/// Был выделен, для создания декоратора. 
/// </summary>
public abstract class TimerInterface : MonoBehaviour
{
    /// <summary>
    /// Called when Timer reaches -1
    /// </summary>
    public abstract event Action TimerEnded;
    public abstract void TurnOn();
    public abstract void TurnOff();
}
