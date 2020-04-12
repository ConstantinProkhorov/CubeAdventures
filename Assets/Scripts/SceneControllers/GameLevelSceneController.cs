using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelSceneController : MonoBehaviour
{
    // я отдаю себе отчет в том, что это god class. Но план такой - я постепенно делаю всё модулями. Потом, когда система уже почти полностью
    // модульная - переделываю это
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
    //public CurrencyGainedOnLevel ScoreGainedOnLevel { get; private set; }
    //public CurrencyGainedOnLevel DiamondsGainedOnLevel { get; private set; }
    private bool LevelIsEnding { get; set; } = false;
    public string LevelName { get => levelName; private set => levelName = value; }
    public void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        Player = PlayerAssembler.Player_Creator(SceneController.LastForm);
        ActiveLevelData.Set(LevelDataInput);
        SceneController.LastLevel = LevelName;                               // перезапись последнего уровня в который играл игрок
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
}
