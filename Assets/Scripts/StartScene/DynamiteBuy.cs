using System;
using UnityEngine;
using UnityEngine.UI;

public class DynamiteBuy : MonoBehaviour
{
    [SerializeField] int DynamitePrice = 10;
    [SerializeField] GameObject DynamitePriceText;
    [SerializeField] StartSceneController startSceneController;
    public void Click()
    {
        if (SceneController.Score >= DynamitePrice)
        {
            SceneController.Score -= DynamitePrice;
            SceneController.Dynamite += 1;
            startSceneController.ReloadDisplayAmmounts();
        }
    }
    private void Start()
    {
        DynamitePriceText.GetComponent<Text>().text= DynamitePrice.ToString();
    }
}