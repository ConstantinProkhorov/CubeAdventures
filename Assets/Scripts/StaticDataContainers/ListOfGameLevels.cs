using System.Collections.Generic;
// это данные, которые не перезаписываются.
// логично сделать их статическими, для удобного доступа, да?
// этот класс предоставляет интерфейс, если я его не меняю, все операции над именами игровых уровней можно размещать здесь.
/// <summary>
/// Provides operations on List of game levels names.
/// </summary>
public static class ListOfGameLevels
{
    private static List<string> ListOfLevels = new List<string>
            {
                "GameLevel 1",
                "GameLevel 2",
                "GameLevel 3",
                "GameLevel 4",
                "GameLevel 5",
                "GameLevel 6",
                "GameLevel 7",
                "GameLevel 8",
                "GameLevel 9",
                "GameLevel 10",
                "GameLevel 11",
                "GameLevel 12",
            };
    /// <summary>
    /// Provides the name of the first game level.
    /// </summary>
    public static string FirstLevelName { get => ListOfLevels[0]; }
    /// <summary>
    /// Returns name of the next game level after the one which name was provided as parameter.
    /// </summary>
    /// <returns>If level is last one returns name of the StartScene/</returns>
    public static string GetNextLevel(string levelName)
    {
        int indexOfLevel = ListOfLevels.IndexOf(levelName) + 1;
        if (indexOfLevel < ListOfLevels.Count)
        {
            return ListOfLevels[indexOfLevel];
        }
        else return "StartScene";
    }
    /// <summary>
    /// Return true if scene with provided name is GameLevel Scene.
    /// </summary>
    /// <param name="levelName">Name of the scene in question.</param>
    public static bool IsGameLevel(string sceneName) => ListOfLevels.Contains(sceneName);
}
