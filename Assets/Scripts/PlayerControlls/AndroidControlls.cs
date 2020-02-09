using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidControlls : MonoBehaviour, IDragHandler

{
    public LevelSceneController _LevelSceneController;
    float PlayerRadius;
    float minX, maxX, minY, maxY;
    public static bool GameIsPaused = false;
    public int Sens = 100; //настройка чувствительности
    private GameObject Player;
    Transform LeftFoot;
    Transform RightFoot;
    float ymin = 2;
    float ymax = 0.85f;
    [SerializeField] float rotationSpeed = 0.01f;
    Vector3 LeftFootPosition;
    Vector3 RightFootPosition;

    void Start()
    {
        minX = ScreenBorders.Left;
        maxX = ScreenBorders.Right;
        minY = ScreenBorders.Buttom;
        maxY = ScreenBorders.Top;
        Player = _LevelSceneController.Player;
        PlayerRadius = Player.transform.localScale.x / 2;
        LeftFoot = Player.transform.GetChild(2);
        RightFoot = Player.transform.GetChild(3);
        LeftFootPosition = LeftFoot.position;
        RightFootPosition = RightFoot.position;
    }
    // возникшее подлагивание скорее всего вызвана работой физики движка в fixedupdate. В данном случае, мне так сейчас кажется, было бы разумнее вызывать событие при 
    // отрывании пальца от экрана. И можно было бы просто значения скорости падения домножать на 0,2, как и скорость работы таймера. Но при текущей "архитектуре" придется 
    // подписывать на события десяток классов, если не больше. Что сделает связанность между классами просто невыносимой. 
    void OnMouseDown()
    {
        if (!GameIsPaused)
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f;
        }
    }
    void OnMouseUp()
    { 
        if (!GameIsPaused)
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }    
    }
    
    void Update()
    {
        if (Player.transform.rotation.z < 0)
        {
            Player.transform.Rotate(Vector3.forward, 0.3f, Space.World);
        }
        if(Player.transform.rotation.z > 0)
        {
            Player.transform.Rotate(Vector3.back, 0.3f, Space.World);
        }
        if (Player.transform.rotation.x > 0)
        {
            Player.transform.Rotate(Vector3.left, 0.3f, Space.World);
        }
        if (Player.transform.rotation.x < 0)
        {
            Player.transform.Rotate(Vector3.right, 0.3f, Space.World);
        }
        if (Player.transform.rotation.y > 0)
        {
            Player.transform.Rotate(Vector3.down, 0.3f, Space.World);
        }
        if (Player.transform.rotation.y < 0)
        {
            Player.transform.Rotate(Vector3.up, 0.3f, Space.World);
        }

        LeftFootPosition.y = Mathf.Clamp(LeftFoot.position.y + (float)0.1, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
        LeftFoot.position = LeftFootPosition;

        RightFootPosition.y = Mathf.Clamp(RightFoot.position.y + (float)0.1, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
        RightFoot.position = RightFootPosition;

        LeftFootPosition.x = Player.transform.position.x - (float)0.3;
        RightFootPosition.x = Player.transform.position.x + (float)0.3;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameIsPaused) //TODO: почему тут своя переменная? Зачем так, может переделать?
        {

            Vector3 playerPosition = Player.transform.position;
            float XSens = eventData.delta.x / Sens;
            float YSens = eventData.delta.y / Sens;
            playerPosition.x = Mathf.Clamp(Player.transform.position.x + XSens, minX + PlayerRadius, maxX - PlayerRadius);
            playerPosition.y = Mathf.Clamp(Player.transform.position.y + YSens, minY + PlayerRadius * 2, maxY + PlayerRadius);
            Player.transform.position = playerPosition;
            PlayerRotation();
            ChangeFootPosition(YSens);
        }
    }
    private void ChangeFootPosition(float YSens) //TODO: перенести в отдельный класс, класс уже создан
    {
        if (YSens != 0)
        {
            LeftFootPosition.y = Mathf.Clamp(LeftFoot.position.y + 2 * -YSens, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            LeftFoot.position = LeftFootPosition;

            RightFootPosition.y = Mathf.Clamp(RightFoot.position.y + 2 * -YSens, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
            RightFoot.position = RightFootPosition;
        }
    }
    private void PlayerRotation()
    {
        Player.transform.Rotate (Vector3.forward, -Input.GetAxis("Mouse X") * rotationSpeed, Space.World);
        Player.transform.Rotate(Vector3.left, -Input.GetAxis("Mouse Y") * rotationSpeed, Space.World);
    }
    public void OnEndDrag(PointerEventData eventData){
    }
    public void OnBeginDrag(PointerEventData eventData) { }
}
