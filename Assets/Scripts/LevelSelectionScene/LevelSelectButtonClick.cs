using UnityEngine;
// обрабатывает клик по кнопке c запуском окна разблокировки за очки
public class LevelSelectButtonClick : MonoBehaviour
{
    public BaseController InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;
    public BuyWindow buyWindow;
    private string ButtonName;

    public void Start()
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport;
        ButtonName = gameObject.name;
    }
    public void OnClick() // вызов метода настроен через инспектор в юнити
    {
        if (thisSceneController.UnlockDictionary.GetState(ButtonName)) 
        {
            SceneController.LastLevel = ButtonName;
            InspectorAssignmentSceneController.SceneLoad(ButtonName);
        }
        else
        {
            buyWindow.OpenBuyWindow(ButtonName, gameObject);
        }
    }
}
