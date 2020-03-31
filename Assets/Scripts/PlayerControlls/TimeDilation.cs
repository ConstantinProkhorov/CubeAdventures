using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeDilation : MonoBehaviour, IDragHandler
{
    public event Action TimeScaleSlowed;
    public event Action TimeScaleNormalized;
    public void OnDrag(PointerEventData eventData)
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
    public void OnEndDrag(PointerEventData eventData) { }
    public void OnBeginDrag(PointerEventData eventData) { }
}
