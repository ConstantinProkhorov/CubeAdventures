using UnityEngine;
public class LevelDataInput : MonoBehaviour
{
    [Header("Level Settings:")]
    public float FallingSpeed;
    [Tooltip("Seconds between figures spawn")]
    public float EnemySpawnInterval;
    [Tooltip("In seconds")]
    public int LevelDuration;
    [Tooltip("How much score each coin gives")]
    public int ScorePerCoin;
}


