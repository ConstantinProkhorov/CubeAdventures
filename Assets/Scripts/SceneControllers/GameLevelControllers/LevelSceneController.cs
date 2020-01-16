using UnityEngine;

public class LevelSceneController : BaseController
{
    public GameObject Player;
    protected byte buildIndex;
    public string LevelName;
    public Player_Assembler _Player_Assembler;
    public IPriceDictionary Dictionary;
    public LevelDataInput currentLevelData;
    [SerializeField] Timer localTimer;
    public Enemy_Creator EnemyCreator;

    public ScoreGainedOnLevel ScoreGainedOnLevel { get; private set; }

    public LevelSceneController() { }
    
    public LevelSceneController(byte index, string levelName)
    {
        LevelName = levelName;
        buildIndex = index;
        Dictionary = new ContinuePlayingDictionary();
    }
    protected void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса
        ActiveLevelData.Set(currentLevelData);
        Player = _Player_Assembler.Player_Creator(SceneController.lastForm);
        ScoreGainedOnLevel = new ScoreGainedOnLevel();
        //localTimer.TurnOn();
    }
    public void OnDisable()
    {
        ScoreGainedOnLevel.Reset(localTimer.timer);
    }
    public void DecrementEnemyCounter()
    {
        EnemyCreator.EnemyCounter--;
    }

    public void IncrementEnemyCounter(sbyte amount = 1)
    {
        EnemyCreator.EnemyCounter += amount;
    }
}

