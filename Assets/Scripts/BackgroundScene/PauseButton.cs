using UnityEngine;

public delegate void UIController();

public class PauseButton : MonoBehaviour
{
    public static bool PauseClick = false;
    public GameObject ScreenBlur;
    public BlurTransparencyChange blurTransparencyChange;

    public event UIController PauseButtonClicked;
    public void OnMouseDown()
    {
        PauseButtonClicked?.Invoke();
        if (!PauseClick)
        {
            PauseClick = true;
            ScreenBlur.SetActive(true);
            blurTransparencyChange.ButtonClicked = !blurTransparencyChange.ButtonClicked;
            Time.timeScale = 0.0f;
            AndroidControlls.GameIsPaused = true;
        }
        else if (PauseClick)
        {
            PauseClick = false;
            blurTransparencyChange.ButtonClicked = !blurTransparencyChange.ButtonClicked;
            Time.timeScale = 1.0f;
            AndroidControlls.GameIsPaused = false;
        }
    }
    public void PauseEventToNull() //обнуление события при загрузке новой сцены
    {
        PauseButtonClicked = null;
    }
}
