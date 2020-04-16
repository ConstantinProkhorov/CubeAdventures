﻿using System.Collections.Generic;
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
    public static string GetNextLevel(string levelName) => ListOfLevels[ListOfLevels.IndexOf(levelName) + 1];
}
