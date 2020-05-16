using UnityEngine;
using UnityEngine.UI;

public class AvaliabilityDisplay : MonoBehaviour
{
    public Button thisButton;
    public Component InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;
    void Start()
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport;
        if (StatusCheck())
        {
            IconeChange();
        }
    }
    private bool StatusCheck() 
    {
        return thisSceneController.UnlockDictionary.GetState(thisButton.name);       
    }
    public void IconeChange()
    {
        thisButton.transform.GetChild(0).gameObject.SetActive(false);
    }
}
