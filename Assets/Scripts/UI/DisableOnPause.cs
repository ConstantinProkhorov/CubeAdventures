using UnityEngine;

public class DisableOnPause : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectToDisable;
    private PauseButton PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        PauseButton = GameObject.Find("Pause").GetComponent<PauseButton>();
        PauseButton.PauseButtonClicked += DisableGameObject;
    }
    private void DisableGameObject() => GameObjectToDisable.SetActive(!GameObjectToDisable.activeSelf);
    public void OnDisable()
    {
        PauseButton.PauseButtonClicked -= DisableGameObject;
    }
}
