using UnityEngine;

public class ShowPauseOnDilation : MonoBehaviour
{
    DisablePauseOnStartScene disablePauseOnStartScene;
    void Start()
    {
        disablePauseOnStartScene = GameObject.Find("Pause").GetComponent<DisablePauseOnStartScene>();
        GetComponent<TimeDilation>().TimeScaleSlowed += disablePauseOnStartScene.EnablePauseButton;
        GetComponent<TimeDilation>().TimeScaleNormalized += disablePauseOnStartScene.DisablePauseButton;
    }
}
