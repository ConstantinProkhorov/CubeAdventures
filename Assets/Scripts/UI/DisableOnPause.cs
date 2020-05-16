using UnityEngine;
/// <summary>
/// Disables given gameObjects on PauseButtonClicked event.
/// </summary>
public class DisableOnPause : MonoBehaviour
{
    [SerializeField] private GameObject[] GameObjectsToDisable = new GameObject[1];
    private PauseButton PauseButton;
    void Start()
    {
        PauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();
        PauseButton.PauseButtonClicked += DisableGameObject;
    }
    /// <summary>
    /// Sets gameObjects that will be disabled on PauseButtonClicked event.
    /// </summary>
    /// <param name="gameObjects">Any number of GameObjects</param>
    public void SetGameObjectToDisable(params GameObject[] gameObject) => GameObjectsToDisable = gameObject;
    private void DisableGameObject()
    {
        foreach (var item in GameObjectsToDisable)
        {
            item.SetActive(!item.activeSelf);
        }
    }
    public void OnDisable()
    {
        PauseButton.PauseButtonClicked -= DisableGameObject;
    }
}
