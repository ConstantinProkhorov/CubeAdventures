using System;
using UnityEngine.UI;
using UnityEngine;
public class Level_1_Controller : LevelSceneController
{
    public LevelStartUpTimer LevelStartUpTimer;
    public Timer WaveTimer;
    public Text TimerReplacementText;
    private const string levelName = "GameLevel 1";
    public Level_1_Controller() : base(/*buildindex =*/ 8, levelName) { }
    private bool levelIsEnding = false;

    new void Start()
    {
        base.Start();
        SceneController.LastLevel = levelName;        // перезапись последнего уровня в который играл игрок
        LevelStartUpTimer.TimerEnded += new Action(LevelStartTextEnded);
        WaveTimer.TimerEnded += new Action(TimerAtZero);
        levelIsEnding = false;
    }

    public void Update()
    {
        if (levelIsEnding & EnemyCreator.EnemyCounter <= 0)
        {
            SceneLoad("WinScore");
        }
    }

    private void LevelStartTextEnded() // метод для события окончания проигрывания вступительного текста
    {
        //выключение текста через его внутренний метод
        LevelStartUpTimer.TurnOff();
        //запуск таймера
        WaveTimer.TurnOn();
        // включение Enemy_Creator
        EnemyCreator.isActive = true;
    }

    private void TimerAtZero()
    {
        WaveTimer.TurnOff();
        EnemyCreator.isActive = false;
        TimerReplacementText.gameObject.SetActive(true);
        levelIsEnding = true;
    }
}
