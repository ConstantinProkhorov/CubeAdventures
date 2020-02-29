using System;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public event EventHandler TimerFinshed;
    private bool isTurnedOn = false;
    private float CountDown;
    public void TurnOn(float timeToCount)
    {     
        CountDown = timeToCount;
        isTurnedOn = true;
    }
    public void TurnOff()
    {
        isTurnedOn = false;
    }
    public void FixedUpdate()
    {
        if (isTurnedOn)
        {
            CountDown -= Time.fixedDeltaTime;
            if (CountDown <= 0)
            {
                TimerFinshed(this, new EventArgs());
                TurnOff();
            }
        }
    }
}
