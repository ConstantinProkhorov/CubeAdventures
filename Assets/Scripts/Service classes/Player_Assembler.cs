using UnityEngine;

public class Player_Assembler : MonoBehaviour
{
    public GameObject _player;
    [SerializeField] GameObject Eyes = null;
    [SerializeField] GameObject Mouth = null;
    [SerializeField] RuntimeAnimatorController AnimatorController = null;
    private GameObject LeftFoot;
    private GameObject RightFoot;

    private readonly string[] Figures = { "Forms/Cube", "Forms/Sphere", "Forms/Cube", "Forms/Cube"/*, "Forms/Cube", "Forms/Cube" */};
    public int FiguresQuantity
    {
        get { return Figures.Length; }
    }
    public GameObject Player_Creator(string s) // вызывается из игрового уровня   
    {
        _player = Resources.Load<GameObject>(s) as GameObject;
        _player = Instantiate(_player, new Vector3(0, ScreenBorders.Bottom + 3*_player.transform.lossyScale.x, 0), Quaternion.identity);
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;
        _player.layer = 2; // установка слоя IgnoreRaycast 
        SphereCollider coll = _player.AddComponent<SphereCollider>();
        coll.radius = 0.4f;
        _player.AddComponent<SizeChange>();
        _player.AddComponent<OnCollision>();
        _player.AddComponent<AudioSource>();
        EyesAndLegsInstantiation(_player);
        return _player;
    }
    public void Player_Creator(Vector3 position, string s) //вызывается из меню
    {
        _player = Resources.Load<GameObject>(s) as GameObject;
        _player = Instantiate(_player, position, Quaternion.identity);
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;
        // размер фигуры игрока на старте
        _player.transform.localScale = Vector3.one;
        EyesAndLegsInstantiation(null);
    }
    public GameObject Player_Creator(Vector3 position, string lastForm, float playerSize) //вызывается из сцены магазина
    {
        _player = Resources.Load<GameObject>(lastForm) as GameObject ?? Resources.Load <GameObject>(SceneController.LastForm) as GameObject ;
        _player = Instantiate(_player, position, Quaternion.identity);
        _player.GetComponent<MeshRenderer>().material.color = SceneController.PlayerCurrentColor;
        _player.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
        EyesAndLegsInstantiation(null);

        return _player;
    }   
    public Vector3 RandomRotation()
    {
        float rotationX = Random.Range(20.0f, 720.0f);
        float rotationY = Random.Range(20.0f, 720.0f);
        float rotationZ = Random.Range(20.0f, 720.0f);
        return new Vector3(rotationX, rotationY, rotationZ);
    }
    private void EyesAndLegsInstantiation(GameObject player)
    {
        LeftFoot = Resources.Load<GameObject>("Forms/LeftFootFrog_") as GameObject;
        RightFoot = Resources.Load<GameObject>("Forms/RightFoot") as GameObject;

        float LegsXPosition = _player.transform.position.x - _player.transform.lossyScale.x / 2.5f;
        float LegsYPosotion = _player.transform.position.y - _player.transform.lossyScale.y/2;

        Eyes = Instantiate(Eyes, new Vector3(_player.transform.position.x, _player.transform.position.y + 0.3f, - 0.55f),Quaternion.identity, _player.transform);
        Mouth = Instantiate(Mouth, new Vector3(_player.transform.position.x, _player.transform.position.y, -0.55f), Quaternion.identity, _player.transform);
        if (player != null)
        {
        DisableOnPause disableOnPause = player.AddComponent<DisableOnPause>();
        disableOnPause.SetGameObjectToDisable(Eyes, Mouth);
        }
        LeftFoot = Instantiate(LeftFoot, new Vector3(LegsXPosition, LegsYPosotion, 0), Quaternion.identity, _player.transform);
        RightFoot = Instantiate(RightFoot, new Vector3(-LegsXPosition, LegsYPosotion, 0), Quaternion.identity, _player.transform);

        _player.AddComponent<Animator>(); //Контроллер анимаций глаз и рта.
        _player.GetComponent<Animator>().runtimeAnimatorController = AnimatorController;
    }
}
