using System.Collections.Generic;

public class ListOfGameLevels
{
    private List<string> ListOfLevels = new List<string>
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

    public string GetNextLevel(string levelName) => ListOfLevels[ListOfLevels.IndexOf(levelName) + 1];
}
