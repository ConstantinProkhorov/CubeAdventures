using System.Collections.Generic;
/// <summary>
/// Provides List of Scene where gamelevel music should be played.
/// </summary>
//HACK: probably a hack, should be remade.
public static class ListOfScenesToPlayGameLevelMusic
{
    private static List<string> ListOfScenes = new List<string>
            {
                "EndScore",
                "WinScore"
            };
    /// <summary>
    /// Return true if scene with provided name is in the list.
    /// </summary>
    /// <param name="levelName">Name of the scene in question.</param>
    public static bool Contains(string sceneName) => ListOfScenes.Contains(sceneName);
}
