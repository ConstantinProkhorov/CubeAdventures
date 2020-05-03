using UnityEngine;
/// <summary>
/// Oбрабатывает клик по кнопке c запуском окна разблокировки за очки.
/// </summary>
public class LevelSelectButtonClick : MonoBehaviour
{
    public SelectLevelController InspectorAssignmentSceneController;
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
            SceneLoadManager.SceneLoad(ButtonName);
        }
        else
        {
            buyWindow.OpenBuyWindow(gameObject);
        }
    }
}
