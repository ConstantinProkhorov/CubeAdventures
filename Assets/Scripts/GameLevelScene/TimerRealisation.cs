using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// TimerRealisation made for GameLevel scene.
/// </summary>
public sealed class TimerRealisation : TimerInterface
{
    public override event Action TimerEnded;
    [SerializeField] private Text TimerDisplay = null;
    [SerializeField] private float TimerCountdownStep = 1.0f;
    public float timer { get; private set; }
    public override void TurnOn()
    {
        timer = ActiveLevelData.LevelDuration;
        StartCoroutine(nameof(OutputTime));
    }
    /// <summary>
    /// Deactivates whole gameobject of this timer. For better or worse.=
    /// </summary>
    public override void TurnOff() => StopCoroutine(nameof(OutputTime));
    IEnumerator OutputTime()
    {
        for (; ; )
        {           
            if (timer >= 0)
            {
                TimerDisplay.text = string.Format("{0:00}:{1:00}", (int)timer / 60, (int)timer % 60);
                timer -= TimerCountdownStep;
            }
            else
            {
                TimerEnded();
            }
            yield return new WaitForSecondsRealtime(TimerCountdownStep);
        }
    }
}
