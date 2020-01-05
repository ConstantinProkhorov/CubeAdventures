using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidControlls : MonoBehaviour, IDragHandler

{
    public LevelSceneController _LevelSceneController;
    float PlayerRadius;
    float minX, maxX, minY;
    public static bool GameIsPaused = false;
    public int Sens = 100; //настройка чувствительности
    private GameObject Player;
    Transform LeftFoot;
    Transform RightFoot;
    float ymin = 2;
    float ymax = (float) 1;
    [SerializeField] float rotationSpeed = 0.01f;
    Vector3 LeftFootPosition; 
    Vector3 RightFootPosition;

    void Start()
    {
        minX = ScreenBorders.Left;
        maxX = ScreenBorders.Right;
        minY = ScreenBorders.Buttom;
        Player = _LevelSceneController.Player;
        PlayerRadius = Player.transform.localScale.x / 2;
        LeftFoot = Player.transform.GetChild(2);
        RightFoot = Player.transform.GetChild(3);
        LeftFootPosition = LeftFoot.position;
        RightFootPosition = RightFoot.position;
    }
    void Update()
    {
        

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
            playerPosition.y = Mathf.Clamp(Player.transform.position.y + YSens, minY + PlayerRadius, 0);
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
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
        Player.transform.Rotate (Vector3.forward, -rotX, Space.World);
    }
    public void OnEndDrag(PointerEventData eventData){ }
    public void OnBeginDrag(PointerEventData eventData) { }
}
