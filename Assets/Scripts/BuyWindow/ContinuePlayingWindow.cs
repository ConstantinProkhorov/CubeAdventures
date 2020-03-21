﻿using UnityEngine;
using UnityEngine.UI;
// класс управления окном для покупки продолжения игры уровня после поражения.
public class ContinuePlayingWindow : MonoBehaviour
{
    public GameObject continuePlayingWindowBlur;
    public Text PriceText;
    public GameLevelSceneController thisSceneController;

    private int Price;
    private GameObject CollidingGameObject;
    public void OpenWindow(GameObject collidingGameObject)
    {
        Price = thisSceneController.Dictionary.GetPrice(thisSceneController.LevelName);
        CollidingGameObject = collidingGameObject;
        continuePlayingWindowBlur.SetActive(true);
        PriceText.text = $"{Price.ToString()} diamonds";       
        Time.timeScale = 0.0f;
        AndroidControlls.GameIsPaused = true;
    }
    public void ContinuePlaying()
    {
        Destroy(CollidingGameObject);
        if (SceneController.Diamonds >= Price)
        {
            SceneController.Diamonds -= Price;
            continuePlayingWindowBlur.SetActive(false);
            AndroidControlls.GameIsPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            PriceText.text = "Not enough diamonds!";
        }
    }
    public void CloseWindow()
    {
        continuePlayingWindowBlur.SetActive(false);
        SceneLoadManager.SceneLoad("EndScore");
    }
}