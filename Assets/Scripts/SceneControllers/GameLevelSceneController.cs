using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelSceneController : MonoBehaviour
{
    [Header("Autoassigned")]
    public GameObject Player;
    [Header("Assigned manualy")]
    [SerializeField] private string levelName = "GameLevel X";
    [SerializeField] private Player_Assembler PlayerAssembler;
    [SerializeField] private LevelDataInput LevelDataInput;
    [SerializeField] private Enemy_Creator EnemyCreator;
    [SerializeField] private LevelStartUpTimer LevelStartUpTimer;
    [SerializeField] private TimerInterface WaveTimer;
    [SerializeField] private Text WaveTimerText;
    //Assigned or changed in runtime
    public ScoreGainedOnLevel ScoreGainedOnLevel { get; private set; }
    private bool LevelIsEnding { get; set; } = false;
    public string LevelName { get => levelName; private set => levelName = value; }
    public void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        ActiveLevelData.Set(LevelDataInput);
        SceneController.LastLevel = LevelName;                               // перезапись последнего уровня в который играл игрок
        SceneController.CurrentWaveName = GetComponent<LevelDataInput>().WaveName;
        Player = PlayerAssembler.Player_Creator(SceneController.LastForm);
        ScoreGainedOnLevel = new ScoreGainedOnLevel();
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
            LevelIsEnding = true;
            InvokeRepeating(nameof(EndLevel), 2.0f, 2.0f);
        };
        // подписка на события OnCollision для проигрывания звуков в нужный момент
        // идея в том, что soundmanager & oncollision не зависят ни от кого, не имеют связей друг с другом и по идеи независыми. Единственное, 
        // что этот класс очень сильные связи с ними имеет, они не разорваны никаким интерфейсом. Первое правило солид нарушено. Я буду додумывать результат по 
        // факту написания всей системы. Но я не понимаю как разорвать эту связь интерфейсом. как сделать эти части независимыми от конкретной реализации???
        // может быть я просто тупой?
        // какой опысный и неоптимальный код...
        //OnCollision onCollision = Player.GetComponent<OnCollision>();
        //SoundHolder soundHolder = GameObject.Find("SoundHolder").GetComponent<SoundHolder>();
        //onCollision.CoinCollision += () => soundHolder.PlayCoinSound();
    }
    private void EndLevel()
    {
        if (LevelIsEnding & !AnyEnemiesLeft())
        {
            SceneController.CurrentSessionPlayerData.TotalWavesCleared++;
            SceneLoadManager.SceneLoad("WinScore");
        }
        bool AnyEnemiesLeft()
        {
            if (GameObject.FindGameObjectWithTag("Enemy") != null) 
                return true;
            else if (GameObject.FindGameObjectWithTag("pointsgiver") != null) 
                return true;
            else if (GameObject.FindGameObjectWithTag("collectible") != null) 
                return true;
            else 
                return false;
        }
    }
    public void OnDisable() => ScoreGainedOnLevel.SaveScore();
}
