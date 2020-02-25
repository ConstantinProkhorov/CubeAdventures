using System;
using UnityEngine.UI;
public class Level_11_Controller : LevelSceneController
{
    public LevelStartUpTimer LevelStartUpTimer;
    public Timer WaveTimer;
    public Text TimerReplacementText;
    public Level_11_Controller() : base(/*buildindex =*/ 18) { }
    private bool levelIsEnding = false;

    new void Start()
    {
        base.Start();
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
