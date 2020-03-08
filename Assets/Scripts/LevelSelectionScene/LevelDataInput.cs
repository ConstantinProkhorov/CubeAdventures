using UnityEngine;
public class LevelDataInput : MonoBehaviour
{
    public string WaveName;
    public float fallingSpeed;
    public bool timerIsNeeded;
    public int PointsPerSecond;
    [Tooltip("Seconds between figures spawn")]
    public float EnemySpawnInterval;
    // variables for setting subtraction amount for case of losing
    public int PointsSubtractionAmount;
    public int DiamondsSubtractAmount;
    [Tooltip("In seconds")]
    public int Timer;
}


