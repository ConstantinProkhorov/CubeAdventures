using UnityEngine;
// я не уверен, что этот класс нужен, но по идеи с ним доступ ко всем статическим неизменяемым данным производится
// единообразно для всех пользователей.
// вот первая проблема этой хуйни. Я начинаю отовсюду запрашивать сюда доступ. Это проблема? То есть множество классов оказываются зависимы от
// этого и от его интерфейса. Ладно, пройдем этот путь до конца).
/// <summary>
/// Access all ingame runtime immutable data through this class.
/// </summary>
public class GameData : MonoBehaviour
{
    /// <summary>
    /// Provides wave name assosiated with game level.
    /// </summary>
    public static IStaticDataContainer LevelWaveName;
    /// <summary>
    /// Provides restart price assosiated with game level.
    /// </summary>
    public static IStaticDataContainer RestartLevelPrice;
    /// <summary>
    /// Price to buy one dynamite.
    /// </summary>
    public static int DynamitePrice { get; } = 10;
    void Start()
    {
        LevelWaveName = new WavesNamesDictionary();
        RestartLevelPrice = new LevelRestartPrice();
    }
}
