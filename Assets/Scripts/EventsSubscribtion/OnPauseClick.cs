using UnityEngine;
using UnityEngine.UI;
// класс блокирует интерфейс при появлении блюров.
// и при нажатии на паузу
// класс должен быть переписан, при переделки системы постановки на паузу, использовать класс DisableOnPause.
public class OnPauseClick : MonoBehaviour
{
    public BuyWindow buyWindow;
    void Start()
    {
        // для кнопки паузы
        GameObject PauseButton = GameObject.Find("Pause");
        PauseButton.GetComponent<PauseButton>().PauseButtonClicked += BlockButton;
        // для интерфейса покупок
        if (buyWindow != null)
        {
            buyWindow.BuyWindowOpen += BlockButton;
        }
    }
    private void BlockButton() // метод блокировки кнопок, оптправляем в событие
    {
        Button button = gameObject.GetComponent<Button>();
        button.interactable = !button.interactable;
    }
}
