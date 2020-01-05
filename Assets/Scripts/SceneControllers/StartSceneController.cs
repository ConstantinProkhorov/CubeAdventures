using UnityEngine;

public class StartSceneController : BaseController
{
    private const byte buildIndex = 1;
    [SerializeField] private Player_Assembler PlayerAssembler;
    void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса
        PlayerAssembler.Player_Creator(new Vector3(0, 1, 0), SceneController.lastForm);
    }
}
