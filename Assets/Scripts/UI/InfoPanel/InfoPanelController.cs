using UnityEngine;
/// <summary>
/// Uses strategy pattern to change infopanel output on runtime.
/// </summary>
public class InfoPanelController : MonoBehaviour
{
    [SerializeField] private InfoPanelDisplay TotalDisplay;
    [SerializeField] private InfoPanelDisplay GainedDisplay;
    private InfoPanelDisplay CurrentInfoPanelDisplay;
    // Start is called before the first frame update
    void Start()
    {
        CurrentInfoPanelDisplay = TotalDisplay;
        SceneLoadManager.NewSceneLoaded += (string currentActiveScent, string sceneToBeLoaded) =>
        {
            if (ListOfGameLevels.IsGameLevel(sceneToBeLoaded))
            {
                CurrentInfoPanelDisplay = GainedDisplay;
            }
            else if (!ListOfGameLevels.IsGameLevel(sceneToBeLoaded))
            {
                CurrentInfoPanelDisplay = TotalDisplay;
            }
        };
    }
    public void FixedUpdate()
    {
        CurrentInfoPanelDisplay.Display();
    }
}
