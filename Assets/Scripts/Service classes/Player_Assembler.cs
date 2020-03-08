using UnityEngine;

public class Player_Assembler : MonoBehaviour
{
    public GameObject _player;
    public GameObject LeftEye;
    public GameObject RightEye;
    public GameObject LeftFoot;
    public GameObject RightFoot;

    private readonly string[] Figures = { "Forms/Cube", "Forms/Sphere", "Forms/Cube", "Forms/Cube"/*, "Forms/Cube", "Forms/Cube" */};
    public int FiguresQuantity
    {
        get { return Figures.Length; }
    }

    public GameObject Player_Creator(string s) // вызывается из игрового уровня   
    {
        _player = Resources.Load<GameObject>(s) as GameObject;
        _player = Instantiate(_player, new Vector3(0, ScreenBorders.Buttom + 3*_player.transform.lossyScale.x, 0), Quaternion.identity);
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;
        _player.layer = 2; // установка слоя IgnoreRaycast 
        BoxCollider coll = _player.AddComponent<BoxCollider>();
        coll.size = new Vector3(1.0f, 1.0f, 1.0f);
        _player.AddComponent<SizeChange>();
        _player.AddComponent<OnCollision>();
        
        EyesAndLegsInstantiation();
        AddLegsControllers();
        
        return _player;
    }
    public void Player_Creator(Vector3 position, string s) //вызывается из меню
    {
        _player = Resources.Load<GameObject>(s) as GameObject;
        _player = Instantiate(_player, position, Quaternion.identity);
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;
        // размер фигуры игрока на старте
        _player.transform.localScale = Vector3.one;

        //запуск анимации
        Animation anim = _player.AddComponent<Animation>();
        AnimationClip clip = Resources.Load<AnimationClip>("StartCubeAnimation") as AnimationClip;
        anim.AddClip(clip, "StartCubeAnimation");
        anim.Play("StartCubeAnimation", PlayMode.StopAll);

        EyesAndLegsInstantiation();
    }

    public GameObject Player_Creator(Vector3 position, int i) //набор фигур для выбора из меню крафта
    {
        _player = Resources.Load<GameObject>(Figures[i]) as GameObject;
        _player = Instantiate(_player, position, Quaternion.Euler(RandomRotation()));
        _player.name = Figures[i];

        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;

        _player.transform.localScale = Vector3.one; // размер фигуры игрока на старте

        _player.AddComponent<FormsSlide>(); 
        _player.AddComponent<BoxCollider>();

        return _player;
    }
    public GameObject Player_Creator(Vector3 position, string lastForm, float playerSize) //вызывается из сцены крафта
    {
        _player = Resources.Load<GameObject>(lastForm) as GameObject ?? Resources.Load <GameObject>(SceneController.lastForm) as GameObject ;
        _player = Instantiate(_player, position, Quaternion.Euler(RandomRotation()));
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;

        Debug.Log(playerSize);
        _player.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
        _player.AddComponent<RotationControlls>();

        EyesAndLegsInstantiation();

        return _player;
    }   

    public Vector3 RandomRotation()
    {
        float rotationX = Random.Range(20.0f, 720.0f);
        float rotationY = Random.Range(20.0f, 720.0f);
        float rotationZ = Random.Range(20.0f, 720.0f);
        return new Vector3(rotationX, rotationY, rotationZ);
    }

    private void EyesAndLegsInstantiation()
    {
        LeftEye = Resources.Load<GameObject>("Forms/NewLeftEye") as GameObject;
        RightEye = Resources.Load<GameObject>("Forms/NewRightEye") as GameObject;
        LeftFoot = Resources.Load<GameObject>("Forms/LeftFoot") as GameObject;
        RightFoot = Resources.Load<GameObject>("Forms/RightFoot") as GameObject;

        float EyesXPosition = _player.transform.position.x + _player.transform.lossyScale.x / 3f; // можно наверное заменить на просто числовые значения
        float EyesYPosition = _player.transform.position.y + _player.transform.lossyScale.y / 3f;
        float EyesZPosition = -0.55f;

        float LegsXPosition = _player.transform.position.x - _player.transform.lossyScale.x / 3f;
        float LegsYPosotion = _player.transform.position.y - _player.transform.lossyScale.y;

        LeftEye = Instantiate(LeftEye, new Vector3(-EyesXPosition, EyesYPosition, EyesZPosition), Quaternion.identity, _player.transform);
        RightEye = Instantiate(RightEye, new Vector3(EyesXPosition, EyesYPosition, EyesZPosition), Quaternion.identity, _player.transform);
        LeftFoot = Instantiate(LeftFoot, new Vector3(LegsXPosition, LegsYPosotion, 0), Quaternion.identity, _player.transform);
        RightFoot = Instantiate(RightFoot, new Vector3(-LegsXPosition, LegsYPosotion, 0), Quaternion.identity, _player.transform);

        LeftEye.AddComponent<OpenCloseEye>();
        RightEye.AddComponent<OpenCloseEye>();
    }
    private void AddLegsControllers()
    {
        LeftFoot.AddComponent<FootController>();
        RightFoot.AddComponent<FootController>();
    }
}
