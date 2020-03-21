using UnityEngine;
using UnityEngine.UI;
// плавно изменяет прозрачность фона при нажатии кнопки меню.
public class BlurTransparencyChange : MonoBehaviour
{   
    Color color;
    public float TransperensyStep = 0.03f;
    public bool ButtonClicked = false;
    void Start()
    {
        color = GetComponent<Image>().color;
    }
    void Update() 
    {
        if (ButtonClicked && color.a < 0.9f)
        {
            color.a += TransperensyStep;
            GetComponent<Image>().color = color;
        }
        else if (!ButtonClicked)
        {
            gameObject.SetActive(false);
            if (color.a > 0.2f)
            {
                color.a -= TransperensyStep;
                GetComponent<Image>().color = color;
            }
        }
    }
    public void ResetColor()
    {
        color.a = 0.0f;
        GetComponent<Image>().color = color;
        ButtonClicked = false;
    }
}
