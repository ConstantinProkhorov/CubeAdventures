using UnityEngine;

public class DiscardProgressOnLose : MonoBehaviour
{
    public void DiscardProgress()
    {
         SceneController.LastLevel = ListOfGameLevels.FirstLevelName;
    }
}
