using System;
using UnityEngine;
using UnityEngine.UI;
public class LevelStartUpTimer : MonoBehaviour
{
    public TimerAnimation TimerAnimation;
    public event Action TimerEnded;
    [SerializeField] private Text Timer;
    private float time = 1;
    private readonly string[] CountDownText = { "3", "2", "1", "GO!" };
    private int IndexValue;
    public void FixedUpdate()
    { 
        if (time >= 1 & IndexValue < CountDownText.Length)
        {
            time = 0;
            Timer.text = CountDownText[IndexValue];
            TimerAnimation.RunAnimation(Timer);
            IndexValue++;
        }
        else if (time >= 1)
        {
            TimerEnded();
        }
        time += Time.fixedDeltaTime;
    }
    public void TurnOff() => gameObject.SetActive(false);
}
