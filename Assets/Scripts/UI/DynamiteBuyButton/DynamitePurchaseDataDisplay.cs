using UnityEngine;
using UnityEngine.UI;

public class DynamitePurchaseDataDisplay : MonoBehaviour
{
    [SerializeField] private BuyDinamite BuyDinamite = null;
    [SerializeField] private Text AmountToBuyText = null;
    [SerializeField] private Text TotalPriceText = null;  
    private void Start()
    {
        AmountToBuyText.text += BuyDinamite.AmountToBuy.ToString();
        TotalPriceText.text = BuyDinamite.TotalBuyPrice.ToString();
    }
}