static class ActiveLevelData
{
    private static float fallingSpeed;
    public static string WaveName { get; private set; }
    public static float FallingSpeed { get => -fallingSpeed; }
    public static float EnemySpawnInterval { get; private set; }
    public static int LevelDuration { get; private set; }   
    public static void Set(LevelDataInput data)
    {
        WaveName = data.WaveName;
        fallingSpeed = data.FallingSpeed;
        EnemySpawnInterval = data.EnemySpawnInterval;
        LevelDuration = data.LevelDuration;
    }
}
