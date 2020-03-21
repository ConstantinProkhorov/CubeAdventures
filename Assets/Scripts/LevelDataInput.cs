using UnityEngine;
public class LevelDataInput : MonoBehaviour
{
    [Header("Level Settings:")]
    public string WaveName;
    public float FallingSpeed;
    [Tooltip("Seconds between figures spawn")]
    public float EnemySpawnInterval;
    [Tooltip("In seconds")]
    public int LevelDuration;
}


