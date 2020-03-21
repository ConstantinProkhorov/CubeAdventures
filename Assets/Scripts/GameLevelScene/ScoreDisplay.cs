﻿using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;
    public GameLevelSceneController thisSceneController;
    private string TotalScore;
    void Start()
    {
        TotalScore = SceneController.Score.ToString();
    }
    void FixedUpdate()
    {
        scoreDisplay.text = $"{TotalScore} (+{thisSceneController.ScoreGainedOnLevel})";
    }
}
