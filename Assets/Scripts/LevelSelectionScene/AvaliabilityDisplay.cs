using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvaliabilityDisplay : MonoBehaviour
{
    //public Sprite LockedIcon;
    //public Sprite UnlockedIcon;
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
        //thisButton.image.overrideSprite = UnlockedIcon;
    }
}
