using UnityEngine;
// плавно изменяет прозрачность фона при нажатии кнопки меню.
public class BlurTransparencyChange : MonoBehaviour
{
    public Material matt;
    private Color color;
    public float TransperensyStep = 0.03f;
    public bool ButtonClicked = false;
    void Start() //обращается напряму к материалу. Не могу понять это вменяемое решение или нет.
    {
        color = matt.color;
    }

    void Update() 
    {
        if (ButtonClicked && color.a < 0.7f)
        {
            color.a += TransperensyStep;
            matt.color = color;
        }
        else if (!ButtonClicked)
        {
            if (color.a > 0.0f)
            {
                color.a -= TransperensyStep;
                matt.color = color;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetColor()
    {
        color.a = 0.0f;
        matt.color = color;
        ButtonClicked = false;
    }
}
