using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class Timer : MonoBehaviour
{
    public event Action TimerEnded;
    public Text timerDisplay;

    public float timer { get; private set; }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        timer = ActiveLevelData.Timer;
    }

    public void TurnOff()
    {
        gameObject.SetActive(true);
        timer = ActiveLevelData.Timer;
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            timerDisplay.text = String.Format("{0:00}:{1:00}", (int)timer / 60, (int)timer % 60);
        }
        else if(timer < 0)
        {
            TimerEnded();
        }
    }
}
