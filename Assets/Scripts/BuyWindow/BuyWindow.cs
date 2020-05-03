using UnityEngine;
using UnityEngine.UI;

public class BuyWindow : MonoBehaviour
{
    [SerializeField] private Color32 CanNotUnlockColor = Color.red;
    [SerializeField] private Color32 CanUnlockColor = Color.white;
    [SerializeField] private Button UnlockButton = null;
    public event UIController BuyWindowOpen;
    public GameObject BuyWindowBlur;
    public BlurTransparencyChange blurTransparencyChange;
    public Text PriceText;
    private string ColorButtonName;
    private GameObject Button;
    private PauseButton pauseButton;
    public Component InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;
    int Price;
    public void Start()
    {
        pauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();
    }
    public void OpenBuyWindow(GameObject clickedColorButton)
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport;
        BuyWindowOpen?.Invoke();
        BuyWindowBlur.SetActive(true);
        blurTransparencyChange.ButtonClicked = true;
        ColorButtonName = clickedColorButton.name;
        Price = thisSceneController.PriceDictionary.GetPrice(clickedColorButton.name);
        PriceText.text = $"{Price.ToString()}";
        if (!CanUnlock())
        {
            PriceText.color = CanNotUnlockColor;
            UnlockButton.interactable = false;
        }
        Button = clickedColorButton;
        pauseButton.PauseButtonClicked += CloseBuyWindow;
    }
    public void CloseBuyWindow() 
    {
        BuyWindowOpen?.Invoke();
        blurTransparencyChange.ButtonClicked = false;
        pauseButton.PauseButtonClicked -= CloseBuyWindow;
        UnlockButton.interactable = true;
        PriceText.color = CanUnlockColor;
    }
    public void UnlockLevel()
    {
        if (CanUnlock())
        {
            SceneController.Score -= Price;
            thisSceneController.UnlockDictionary.ChangeState(ColorButtonName);
            Button.GetComponent<AvaliabilityDisplay>().IconeChange();
            CloseBuyWindow();
        }
    }
    private bool CanUnlock() => SceneController.Score >= Price;
    void OnDisable() 
    {
        BuyWindowOpen = null;
    }
}
