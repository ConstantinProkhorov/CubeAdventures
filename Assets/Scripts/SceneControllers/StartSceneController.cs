using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    #region IInfoPanel implementation
    public event Action<int> ScoreChanged;
    public event Action<int> DiamondsChanged;
    public event Action<int> DynamiteChanged;
    #endregion
    [SerializeField] private Player_Assembler PlayerAssembler;
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        PlayerAssembler.Player_Creator(new Vector3(0, 1, 0), SceneController.LastForm);
    }
}
