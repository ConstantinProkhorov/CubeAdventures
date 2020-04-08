using UnityEngine;
/// <summary>
/// Controlls the logic when DynamiteButton is show and when it is hidden
/// </summary>
public class DynamiteButtonController : MonoBehaviour
{
    [SerializeField] private TimeDilation TimeDilation;
    [SerializeField] private GameLevelSceneController thisSceneController;
    [SerializeField] private ShowDynamiteButton ShowDynamiteButton;
    void Start()
    {
        // button needs to be hidden on start
        ShowDynamiteButton.Hide();
        // subscribe to time dilation events
        TimeDilation.TimeScaleSlowed += () =>
        {
            if (SceneController.Dynamite > 0)
            {
                AttachDynamiteButtonToPlayer();
                ShowDynamiteButton.Show();
            }
        };
        TimeDilation.TimeScaleNormalized += () => ShowDynamiteButton.Hide();
        // subscribe to pause/unpause events
        GameObject.Find("Pause").GetComponent<PauseButton>().PauseButtonClicked += () =>
        {
            if (ShowDynamiteButton.IsHidden)
            {
                ShowDynamiteButton.Show();
            }
            else
            {
                ShowDynamiteButton.Hide();
            }
        };
    }
    private void AttachDynamiteButtonToPlayer()
    {
        Transform playerTransform = thisSceneController.Player.transform;
        Vector3 position = playerTransform.position - playerTransform.lossyScale / 2;
        gameObject.transform.position = position;
    }
}
