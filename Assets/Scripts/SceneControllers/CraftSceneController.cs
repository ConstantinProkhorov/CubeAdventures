using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CraftSceneController : MonoBehaviour, IDictionarySupport
{
    #region IInfoPanel implementation
    public event Action<int> ScoreChanged;
    public event Action<int> DiamondsChanged;
    public event Action<int> DynamiteChanged;
    #endregion
    public Player_Assembler _Player_Assembler;
    public static GameObject player;
    [SerializeField] private float playerSize = 1.5f;
    [SerializeField] private Vector3 PlayerModelPosition = new Vector3(0, 3, 6);
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        UnlockDictionary = SceneController.ColorStateDictionary;
        PriceDictionary = SceneController.ColorPriceDictionary;
        player = _Player_Assembler.Player_Creator(PlayerModelPosition, SceneController.LastForm, playerSize);
        ScoreChanged?.Invoke(SceneController.Score);
        DiamondsChanged?.Invoke(SceneController.Diamonds);
        DynamiteChanged?.Invoke(SceneController.Dynamite);
    }
}
