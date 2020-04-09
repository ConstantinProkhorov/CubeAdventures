using UnityEngine;
// я не уверен, что этот класс нужен, но по идеи с ним доступ ко всем статическим неизменяемым данным производится
// единообразно для всех пользователей.
/// <summary>
/// Access all ingame runtime immutable data through this class.
/// </summary>
public class GameData : MonoBehaviour
{
    /// <summary>
    /// Provides wave name assosiated with game level.
    /// </summary>
    public static IStaticDataContainer LevelWaveName;
    public static IStaticDataContainer RestartLevelPrice;
    void Start()
    {
        LevelWaveName = new WavesNamesDictionary();
        RestartLevelPrice = new LevelRestartPrice();
    }
}
