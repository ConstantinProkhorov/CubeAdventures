using UnityEngine;
using UnityEngine.UI;
public class GameLevelSceneController : BaseController
{
    [Header("Autoassigned")]
    public GameObject Player;
    [Header("Assigned manualy")]
    [SerializeField]private string levelName = "GameLevel X";
    [SerializeField]private Player_Assembler PlayerAssembler;
    [SerializeField]private LevelDataInput LevelDataInput;
    [SerializeField]private Enemy_Creator EnemyCreator;
    [SerializeField]private LevelStartUpTimer LevelStartUpTimer;
    [SerializeField]private Timer WaveTimer;
    [SerializeField]private Text TimerReplacementText;
    //Assigned or changed in runtime
    public IPriceDictionary Dictionary { get; private set; }
    public ScoreGainedOnLevel ScoreGainedOnLevel { get; private set; }
    private bool LevelIsEnding { get; set; } = false;
    public string LevelName { get => levelName; private set => levelName = value; }
    public void Start()
    {
        thisSetActive(LevelDataInput.SceneBuildIndex);                       //установка данной сцены активной методом из наследуемого класса
        ActiveLevelData.Set(LevelDataInput);
        SceneController.LastLevel = LevelName;                               // перезапись последнего уровня в который играл игрок
        Player = PlayerAssembler.Player_Creator(SceneController.LastForm);
        ScoreGainedOnLevel = new ScoreGainedOnLevel();
        Dictionary = new ContinuePlayingDictionary(); 
        LevelStartUpTimer.TimerEnded += () => 
        {        
            //выключение текста через его внутренний метод
            LevelStartUpTimer.TurnOff();
            //запуск таймера
            WaveTimer.TurnOn();
            // включение Enemy_Creator
            EnemyCreator.isActive = true;
        };
        WaveTimer.TimerEnded += () => 
        {
            WaveTimer.TurnOff();
            EnemyCreator.isActive = false;
            TimerReplacementText.gameObject.SetActive(true);
            LevelIsEnding = true;
        };
    }
    public void Update()
    {
        if (LevelIsEnding & EnemyCreator.EnemyCounter <= 0)
        {
            SceneController.CurrentSessionPlayerData.TotalWavesCleared++;
            SceneLoad("WinScore");
        }
    }
    public void OnDisable() => ScoreGainedOnLevel.SaveScore();

    // параметры GameObject в этих методах временные, удалить вместе с методом Display();
    public void DecrementEnemyCounter(GameObject obj) => EnemyCreator.EnemyCounter--;

    public void IncrementEnemyCounter(GameObject obj, int amount = 1) => EnemyCreator.EnemyCounter += amount;

    private void Display(GameObject obj) // method for debugging
    {
        Debug.Log("Called by " + obj.name + " Enemy Count = " + EnemyCreator.EnemyCounter);
    }
}
