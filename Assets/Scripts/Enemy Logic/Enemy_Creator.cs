using UnityEngine;
using System.Collections.Generic;
public sealed class Enemy_Creator : EnemySpawnRandomizer 
{
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

    public sbyte EnemyCounter = 0;

    public StepType stepType = StepType.FloatStep;

    public static float figuresize = 0.3f;
    private float spawnPosY;

    private float[] positionArray;

    private float EnemySpawnInterval;
    private float SpawnIntervalStep;
    private void Start()
    {
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
        spawnPosY = ScreenBorders.Top + ScreenBorders.Top / 10;
        positionArray = SpawnPositionCalculator();
        EnemySpawnInterval = ActiveLevelData.EnemySpawnInterval;
        SpawnIntervalStep = ActiveLevelData.SpawnIntervalStep;
    }
    void Update()
    {
        if (isActive)
        {
            timeCount += Time.deltaTime;
            if (timeCount > spawnInterval)
            {
                Enemy_Spawner();
                ++EnemyCounter;
                timeCount = default;
                if (EnemyCounter >= ActiveLevelData.DifficultyIncreaseStep)
                {
                    spawnInterval = GetNewSpawnInterval(stepType, ActiveLevelData.SpawnIntervalStep);
                    EnemyCounter = default;
                }
                else
                    spawnInterval = GetNewSpawnInterval(stepType);
            }
        }
    }
    public void Enemy_Spawner()
    {
        int i = Random.Range(0, 100);
        foreach (var enemy in AllFigures)
        {
            if (enemy.Key != null && i < enemy.Value)
            {
                Instantiate(enemy.Key, new Vector3(Position_Randomizer(positionArray), spawnPosY, 0), Quaternion.identity);
                return;
            }
        }     
    }
    public float GetNewSpawnInterval(StepType stepType)
    {
        if (stepType == StepType.NoStep)
        {
            return EnemySpawnInterval;
        }
        int i = Random.Range(0, 2);
        if (stepType == StepType.FloatStep)
        {
            if (i == 0)
            {
                return EnemySpawnInterval += Random.Range(0, SpawnIntervalStep);
            }
            else
            {
                return EnemySpawnInterval -= Random.Range(0, SpawnIntervalStep);
            }
        }
        else
        {
            if (i == 0)
            {
                return EnemySpawnInterval += SpawnIntervalStep;
            }
            else
            {
                return EnemySpawnInterval -= SpawnIntervalStep;
            }
        }
    }
    public float GetNewSpawnInterval(StepType stepType, float delta)
    {
        return GetNewSpawnInterval(stepType) - delta;
    }
}