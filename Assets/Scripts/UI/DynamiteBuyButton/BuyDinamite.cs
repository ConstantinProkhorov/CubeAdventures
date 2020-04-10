using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Incapsulates data and logic for buying dynamite
/// </summary>
public class BuyDinamite : MonoBehaviour
{
    [SerializeField] private int amountToBuy = 1; 
    [SerializeField] private Button BuyDynamiteButton; 
    //[SerializeField] private StartSceneController startSceneController;
    public int AmountToBuy { get => amountToBuy; }
    public int TotalBuyPrice { get; private set; }
    public void Awake()
    {
        TotalBuyPrice = amountToBuy * GameData.DynamitePrice;
    }
    public void Start()
    {
        BlockButton();
    }
    public void BuyDynamite()
    {
        SceneController.Score -= TotalBuyPrice;
        SceneController.Dynamite += AmountToBuy;
        BlockButton();
    }
    private void BlockButton()
    {
        if (!CanBuy())
        {
            BuyDynamiteButton.interactable = false;
        }
    }
    private bool CanBuy() => SceneController.Score >= TotalBuyPrice;
}
