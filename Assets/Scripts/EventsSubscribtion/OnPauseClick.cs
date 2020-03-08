using UnityEngine;
using UnityEngine.UI;
// класс блокирует интерфейс при появлении блюров.
public class OnPauseClick : MonoBehaviour
{
    public BuyWindow buyWindow;
    void Start()
    {
        // для кнопки паузы
        GameObject PauseButton = GameObject.Find("Pause");
        PauseButton.GetComponent<PauseButton>().PauseButtonClicked += BlockButton;
        // для интерфейса покупок
        buyWindow.BuyWindowOpen += BlockButton;
    }
    private void BlockButton() // метод блокировки кнопок, оптправляем в событие
    {
        Button button = gameObject.GetComponent<Button>();
        button.interactable = !button.interactable;
    }
}
