using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    [SerializeField] private Text FPSDisplayText;
    private float TimeCounter = 1f;
    private int FPSCounter = 0;
    void Update()
    {
        TimeCounter -= Time.deltaTime;
        FPSCounter++;
        if (TimeCounter <= 0)
        {
            FPSDisplayText.text = FPSCounter.ToString();
            TimeCounter = 1.0f;
            FPSCounter = 0;
        }
    }
}
