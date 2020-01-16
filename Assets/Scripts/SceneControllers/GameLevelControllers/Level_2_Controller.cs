//public class Level_2_Controller : LevelSceneController
//{
//    public Level_2_Controller() : base(/*buildindex =*/ 8, /*LevelName =*/ "GameLevel 2") { }
//    new void Start()
//    {
//        base.Start();
//    }
//}
using System;
using UnityEngine.UI;
public class Level_2_Controller : LevelSceneController
{
    public Timer timer;
    public Text TimerReplacementText;
    private const string levelName = "GameLevel 2";
    public Level_2_Controller() : base(/*buildindex =*/ 9, levelName) { }
    private bool levelIsEnding = false;

    new void Start()
    {
        base.Start();
        SceneController.LastLevel = levelName;        // перезапись последнего уровня в который играл игрок
        timer.TimerEnded += new Action(TimerAtZero);
        // подписка на событие окончания вступительного текста += new Action(LevelStartTextEnded);
        LevelStartTextEnded(); // ЭТО ТУТ ВРЕМЕННО!!! пока не переедет в событие
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
        //запуск таймера
        timer.TurnOn();
        // включение Enemy_Creator
        EnemyCreator.isActive = true;
    }

    private void TimerAtZero()
    {
        timer.TurnOff();
        EnemyCreator.isActive = false;
        TimerReplacementText.gameObject.SetActive(true);
        levelIsEnding = true;
    }
}