using UnityEngine;

public class LevelDataInput : MonoBehaviour
{
    public int SceneBuildIndex;
    public float fallingSpeed;
    public bool timerIsNeeded;
    public int PointsPerSecond;
    [Tooltip("Seconds between figures spawn")]
    public float enemySpawnInterval;
    [Tooltip("Possible values are in range from 0.01 to enemySpawnInterval")]
    public float SpawnIntervalStep;
    [Tooltip("Chance in percents to spawn diamond")]
    // variables for setting subtraction amount for case of losing
    public int PointsSubtractionAmount;
    public int DiamondsSubtractAmount;

    [Tooltip("After what amount of enemies spawntime will decrease")] // are you fucking SURE??!1
    public int DifficultyIncreaseStep;
    [Tooltip("In seconds")]
    public int Timer;
}


