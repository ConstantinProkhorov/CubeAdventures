using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CraftSceneController : MonoBehaviour, IDictionarySupport
{
    public Player_Assembler _Player_Assembler;
    public static GameObject player;
    [SerializeField] private float playerSize = 1.0f;
    [SerializeField] private Vector3 PlayerModelPosition = new Vector3(0, 3, 0);
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
        UnlockDictionary = SceneController.ColorStateDictionary;
        PriceDictionary = SceneController.ColorPriceDictionary;
        player = _Player_Assembler.Player_Creator(PlayerModelPosition, SceneController.LastForm, playerSize);
    }
}
