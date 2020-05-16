using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private Player_Assembler PlayerAssembler = null;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        PlayerAssembler.Player_Creator(new Vector3(0, 1, 0), SceneController.LastForm);
    }
}
