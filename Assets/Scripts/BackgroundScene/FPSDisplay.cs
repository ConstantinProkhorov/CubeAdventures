using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text _FPSDisplay;
    float timeCounter;
    float refreshTime = 2;
    void Update()
    {        
        timeCounter += Time.deltaTime;
        if (timeCounter >= refreshTime)
        {
            var fps = 1.0 / Time.deltaTime;
            _FPSDisplay.text = $"fps: {fps:f1}";
        }
    }
}
