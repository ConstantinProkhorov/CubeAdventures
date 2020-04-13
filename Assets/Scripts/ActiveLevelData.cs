static class ActiveLevelData
{
    private static float fallingSpeed;
    public static float FallingSpeed { get => -fallingSpeed; }
    public static float EnemySpawnInterval { get; private set; }
    public static int LevelDuration { get; private set; }
    public static int ScorePerCoin { get; private set; }
    /// <summary>
    /// Updates all variables with values from LevelDataInput in currently active game level scene.
    /// </summary>
    public static void Set(LevelDataInput data)
    {
        fallingSpeed = data.FallingSpeed;
        EnemySpawnInterval = data.EnemySpawnInterval;
        LevelDuration = data.LevelDuration;
        ScorePerCoin = data.ScorePerCoin;
    }
}
