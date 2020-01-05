using UnityEngine;

public class CraftSceneController : BaseController, IDictionarySupport
{
    private const byte buildIndex = 2;
    public Player_Assembler _Player_Assembler;
    public static GameObject player;
    [SerializeField] private float playerSize = 2;
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }

    void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса
        UnlockDictionary = SceneController.ColorStateDictionary;
        PriceDictionary = SceneController.ColorPriceDictionary;

        //загрузка фигуры игрока  
        player = _Player_Assembler.Player_Creator(new Vector3(0, 2, 2), SceneController.lastForm, playerSize);
    }
}
