using System;
using UnityEngine;
public class TimeDilation : MonoBehaviour
{
    public event Action TimeScaleSlowed;
    public event Action TimeScaleNormalized;
    void OnMouseDown()
    {
        Fast();
    }
    void OnMouseUp()
    {
        
        Slow();
        
    }
    public void Fast()
    {
    if (!AndroidControlls.GameIsPaused)
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        TimeScaleNormalized();
    }
    }
    public void Slow()
    {
        if (!AndroidControlls.GameIsPaused)
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            TimeScaleSlowed();

        }
    }
}
