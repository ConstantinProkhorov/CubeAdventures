using UnityEngine;

public class LevelSceneController : BaseController
{
    public GameObject Player;
    protected byte buildIndex;
    public string LevelName;
    public Player_Assembler _Player_Assembler;
    public IPriceDictionary Dictionary;
    public LevelDataInput LevelDataInput;
    public Enemy_Creator EnemyCreator;

    public ScoreGainedOnLevel ScoreGainedOnLevel { get; private set; }

    public LevelSceneController() { }
    
    public LevelSceneController(byte index)
    {
        buildIndex = index;
        Dictionary = new ContinuePlayingDictionary();
    }
    protected void Start()
    {
        thisSetActive(buildIndex);                                          //установка данной сцены активной методом из наследуемого класса
        ActiveLevelData.Set(LevelDataInput);
        SceneController.LastLevel = LevelName;                              // перезапись последнего уровня в который играл игрок
        Player = _Player_Assembler.Player_Creator(SceneController.lastForm);
        ScoreGainedOnLevel = new ScoreGainedOnLevel();
    }
    public void OnDisable()
    {
        ScoreGainedOnLevel.SaveScore();
    }
    public void DecrementEnemyCounter(GameObject obj)
    {
        EnemyCreator.EnemyCounter--;
    }

    public void IncrementEnemyCounter(GameObject obj, int amount = 1)
    {
        EnemyCreator.EnemyCounter += amount;
    }

    private void Display(GameObject obj) // method for debugging
    {
        Debug.Log("Called by " + obj.name + " Enemy Count = " + EnemyCreator.EnemyCounter);
    }
}

