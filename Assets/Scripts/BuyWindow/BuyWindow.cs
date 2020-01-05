using UnityEngine;
using UnityEngine.UI;

public class BuyWindow : MonoBehaviour
{
    public event UIController BuyWindowOpen;
    public GameObject BuyWindowBlur;
    public BlurTransparencyChange blurTransparencyChange;
    public Text PriceText;
    private string Name;
    private GameObject Button;
    private PauseButton pauseButton;
    public Component InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;

    int Price;
    public void Start()
    {
        pauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();
    }
    public void OpenBuyWindow(string name, GameObject _button)
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport;
        BuyWindowOpen?.Invoke();
        BuyWindowBlur.SetActive(true);
        blurTransparencyChange.ButtonClicked = true;
        Name = name;
        Price = thisSceneController.PriceDictionary.GetPrice(name);
        PriceText.text = $"{Price.ToString()} points";
        Button = _button;
        pauseButton.PauseButtonClicked += CloseBuyWindow;
    }
    public void CloseBuyWindow() 
    {
        BuyWindowOpen?.Invoke();
        blurTransparencyChange.ButtonClicked = false;
        pauseButton.PauseButtonClicked -= CloseBuyWindow;
    }
    public void UnlockLevel()
    {
        if (SceneController.score >= Price)
        {
            SceneController.score -= Price;
            thisSceneController.UnlockDictionary.ChangeState(Name);
            Button.GetComponent<AvaliabilityDisplay>().IconeChange();
            CloseBuyWindow();
        }
        else
        {
            PriceText.text = "Not enough points!";
        }
    }
    void OnDisable() 
    {
        BuyWindowOpen = null;
    }
}
