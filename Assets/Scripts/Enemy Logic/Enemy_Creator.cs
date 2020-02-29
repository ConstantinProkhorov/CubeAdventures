using System.Collections.Generic;
using UnityEngine;
public sealed class Enemy_Creator : MonoBehaviour
{//mm
    private EnemySpawnRandomizer EnemySpawnRandomizer;
    private IColorRandomizer ColorRandomizer;
    [SerializeField] GameLevelSceneController ThisSceneController;
    // фигуры врагов и шанс их появления
    #pragma warning disable 649
    [SerializeField] private GameObject enemyA;
    [SerializeField] private int enemyASpawnChance;
    [SerializeField] private GameObject enemyB;
    [SerializeField] private int enemyBSpawnChance;
    [SerializeField] private GameObject enemyC;
    [SerializeField] private int enemyCSpawnChance;
    [SerializeField] private GameObject enemyD;
    [SerializeField] private int enemyDSpawnChance;
    [SerializeField] private GameObject enemyE;
    [SerializeField] private int enemyESpawnChance;
    [SerializeField] private GameObject PointsFigure;
    [SerializeField] private int PointsFigureSpawnChance;
    [SerializeField] private GameObject DiamondFigure;
    [SerializeField] private int DiamondFigureSpawnChance;
    // словарь всех фигур на уровне
    private Dictionary<GameObject, int> AllFigures;
    // переменные для контроля уровня сложности
    // контроль частоты появления фигур
    public bool isActive = false;
    public static float spawnInterval;
    private float timeCount = 0;
    public int EnemyCounter { get; set; } = 0;
    public StepType stepType = StepType.FloatStep;
    public static float figuresize = 0.3f;
    private float EnemySpawnInterval;
    private float SpawnIntervalStep;
    private void Start()
    {

        Debug.Log(EnemyCounter);
        AllFigures = new Dictionary<GameObject, int>
        {
        { PointsFigure, 0 + PointsFigureSpawnChance },
        { DiamondFigure, PointsFigureSpawnChance + DiamondFigureSpawnChance },
        { enemyA, PointsFigureSpawnChance + DiamondFigureSpawnChance + enemyASpawnChance },
        { enemyB, PointsFigureSpawnChance + DiamondFigureSpawnChance + enemyASpawnChance + enemyBSpawnChance },
        { enemyC, PointsFigureSpawnChance + DiamondFigureSpawnChance + enemyASpawnChance + enemyBSpawnChance + enemyCSpawnChance },
        { enemyD, PointsFigureSpawnChance + DiamondFigureSpawnChance + enemyASpawnChance + enemyBSpawnChance + enemyCSpawnChance + enemyDSpawnChance },
        { enemyE,PointsFigureSpawnChance + DiamondFigureSpawnChance + enemyASpawnChance + enemyBSpawnChance + enemyCSpawnChance + enemyDSpawnChance + enemyESpawnChance }
        };
        spawnInterval = GetNewSpawnInterval(stepType);
        EnemySpawnInterval = ActiveLevelData.EnemySpawnInterval;
        SpawnIntervalStep = ActiveLevelData.SpawnIntervalStep;
        ColorRandomizer = new EnemyColorRandomizer(); //в условиях юнити, прикрывая класс абстракцие в виде интерфейса, я не разрываю зависимость и не ослабляю ее, так
        // как все равно остается эта строчка кода. В условиях юнити (и, возможно, не только в них) вероятно нужен третий скрипт, который бы назначал переменные.
        EnemySpawnRandomizer = new EnemySpawnRandomizer();
    }
    void Update() // Ох, надо все это через события писать было... один таймер на уровне может считать время, и рассылать события о прошедшем времени. 
        // а у меня тут сколько раз время считается? три, может больше. 
        // а если мне нужные несогласованные интервалы?
    { // я так понимаю, что правильно решение здесь это использовать фабричный метод, TODO: вчитаться и если надо переписать весь класс
        if (isActive)
        {
            timeCount += Time.deltaTime;
            if (timeCount > spawnInterval)
            {
                Enemy_Spawner();
                ThisSceneController.IncrementEnemyCounter(gameObject);
                timeCount = default;
            }
            if (EnemyCounter >= ActiveLevelData.DifficultyIncreaseStep) // 
            {
                spawnInterval = GetNewSpawnInterval(stepType, ActiveLevelData.SpawnIntervalStep);
                //EnemyCounter = default;
            }
            else
            { 
                spawnInterval = GetNewSpawnInterval(stepType);
            }
        }
    }
    public void Enemy_Spawner()
    {
        GameObject Enemy;
        int i = Random.Range(1, 101);
        foreach (var enemy in AllFigures)
        {
            if (enemy.Key != null && i < enemy.Value)
            {
                Enemy = Instantiate(enemy.Key, EnemySpawnRandomizer.GetRandomSpawnPosition(enemy.Key.name), Quaternion.identity);
                Enemy.GetComponent<EnemyMovement>().thisSceneController = ThisSceneController;
                if (Enemy.name == "Sphere_Enemy(Clone)")
                {
                    ColorRandomizer.AssignColor(Enemy);
                }
                return;
            }
        }
    }
    public float GetNewSpawnInterval(StepType stepType)
    {
        return ActiveLevelData.EnemySpawnInterval;
        //if (stepType == StepType.NoStep)
        //{
        //    return EnemySpawnInterval;
        //}
        //int i = Random.Range(0, 2);
        //if (stepType == StepType.FloatStep)
        //{
        //    if (i == 0)
        //    {
        //        return EnemySpawnInterval += Random.Range(0, SpawnIntervalStep);
        //    }
        //    else
        //    {
        //        return EnemySpawnInterval -= Random.Range(0, SpawnIntervalStep);
        //    }
        //}
        //else
        //{
        //    if (i == 0)
        //    {
        //        return EnemySpawnInterval += SpawnIntervalStep;
        //    }
        //    else
        //    {
        //        return EnemySpawnInterval -= SpawnIntervalStep;
        //    }
        //}
    }
    public float GetNewSpawnInterval(StepType stepType, float delta)
    {
        return GetNewSpawnInterval(stepType) - delta;
    }
}