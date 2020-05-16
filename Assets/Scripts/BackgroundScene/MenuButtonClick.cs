using UnityEngine;
public class MenuButtonClick : MonoBehaviour
{
    // обрабатывает клик по кнопке меню для перехода на новую сцену
    public ButtonsSlideY MenuButtonA, MenuButtonB, MenuButtonC; 
    public void OnMouseDown()
    {
        // возврат кнопок меню в исходное положение
        MenuButtonA.ButtonPositionReset();
        MenuButtonB.ButtonPositionReset();
        MenuButtonC.ButtonPositionReset();
        // загрузка уровня через имя кнопки
        SceneLoadManager.SceneLoad(gameObject.name);
    }
}
