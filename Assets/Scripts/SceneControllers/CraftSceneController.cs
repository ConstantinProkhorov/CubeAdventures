using UnityEngine;

public class CraftSceneController : BaseController, IDictionarySupport
{
    private readonly int buildIndex = 2;
    public Player_Assembler _Player_Assembler;
    public static GameObject player;
    [SerializeField] private float playerSize = 1.5f;
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }

    void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса
        UnlockDictionary = SceneController.ColorStateDictionary;
        PriceDictionary = SceneController.ColorPriceDictionary;

        //загрузка фигуры игрока  
        player = _Player_Assembler.Player_Creator(new Vector3(0, 3, 2), SceneController.LastForm, playerSize);
    }
}
