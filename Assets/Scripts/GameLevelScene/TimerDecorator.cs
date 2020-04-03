using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Decorator for TimerInterface types
/// </summary>
public class TimerDecorator : TimerInterface
{
    public override event Action TimerEnded;
    [SerializeField] private TimerInterface WaveTimer;
    private Color TimerEndedColor = new Color32(9, 173, 41, 255);
    [SerializeField] private Text TimerDisplay;
    public void Start()
    {       
        TimerEnded += () => TimerDisplay.color = TimerEndedColor;
    }
    public override void TurnOn()
    {    
        WaveTimer.TurnOn();
        WaveTimer.TimerEnded += TimerEnded;
    }
    public override void TurnOff() => WaveTimer.TurnOff();
}
