﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScoreSceneController : MonoBehaviour
{     
    public Text scoreNumberDisplay;
    public Text diamondsNumberDisplay;

    public Text scoreSubstractedDisplay;
    public Text diamondsSubstractedDisplay;
    public Text PointsGainedOnLevel;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ScoreSubtraction();
        SubstractionInfoDisplay();
        ResultsDisplay();
    }
    private void ScoreSubtraction() // вычитание очков при проигрыше
    {
        int diamonds = SceneController.Diamonds - ActiveLevelData.DiamondsSubtractAmount;
        SceneController.Diamonds = diamonds < 0 ? 0 : diamonds;
    }
    private void SubstractionInfoDisplay()
    {
        scoreSubstractedDisplay.text = $"As a penalty {ActiveLevelData.PointsSubtractionAmount} points";
        diamondsSubstractedDisplay.text = $"and {ActiveLevelData.DiamondsSubtractAmount} diamonds were subtracted.";
        PointsGainedOnLevel.text = SceneController.ScoreGainedOnLevel.ToString();
    }
    private void ResultsDisplay()
    {
        scoreNumberDisplay.text = SceneController.Score.ToString();
        diamondsNumberDisplay.text = SceneController.Diamonds.ToString();
    }
}
