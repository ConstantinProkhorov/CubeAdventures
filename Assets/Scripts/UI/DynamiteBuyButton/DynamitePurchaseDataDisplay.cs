using UnityEngine;
using UnityEngine.UI;

public class DynamitePurchaseDataDisplay : MonoBehaviour
{
    [SerializeField] private BuyDinamite BuyDinamite;
    [SerializeField] private Text AmountToBuyText;
    [SerializeField] private Text TotalPriceText;  
    private void Start()
    {
        AmountToBuyText.text += BuyDinamite.AmountToBuy.ToString();
        TotalPriceText.text = BuyDinamite.TotalBuyPrice.ToString();
    }
}