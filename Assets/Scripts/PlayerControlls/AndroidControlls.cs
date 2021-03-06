﻿using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidControlls : MonoBehaviour, IDragHandler
{
    public GameLevelSceneController LevelSceneController;
    float PlayerRadius;
    //границы экрана
    float minX, maxX, minY, maxY;
    public static bool GameIsPaused = false;
    public int Sens = 100; //настройка чувствительности
    private GameObject Player;
    Transform LeftFoot;
    Transform RightFoot;
    float ymin = 2.0f;
    float ymax = 0.6f;
    [SerializeField] float rotationSpeed = 0.01f;
    Vector3 LeftFootPosition;
    Vector3 RightFootPosition;
    void Start()
    {
        minX = ScreenBorders.Left;
        maxX = ScreenBorders.Right;
        minY = ScreenBorders.Bottom + 0.25f;
        maxY = ScreenBorders.Top;
        Player = LevelSceneController.Player;
        PlayerRadius = Player.transform.localScale.x / 2;
        LeftFoot = Player.transform.GetChild(2);
        RightFoot = Player.transform.GetChild(3);
        LeftFootPosition = LeftFoot.position;
        RightFootPosition = RightFoot.position;
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

        LeftFootPosition.y = Mathf.Clamp(LeftFoot.position.y + 0.1f, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
        LeftFoot.position = LeftFootPosition;

        RightFootPosition.y = Mathf.Clamp(RightFoot.position.y + 0.1f, Player.transform.position.y - ymin, Player.transform.position.y - ymax);
        RightFoot.position = RightFootPosition;

        LeftFootPosition.x = Player.transform.position.x - 0.35f;
        RightFootPosition.x = Player.transform.position.x + 0.35f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!GameIsPaused) //TODO: почему тут своя переменная? Зачем так, может переделать?
        {
            Vector3 playerPosition = Player.transform.position;
            float XSens = eventData.delta.x / Sens;
            float YSens = eventData.delta.y / Sens;
            playerPosition.x = Mathf.Clamp(Player.transform.position.x + XSens, minX + PlayerRadius, maxX - PlayerRadius);
            playerPosition.y = Mathf.Clamp(Player.transform.position.y + YSens, minY + PlayerRadius, maxY - PlayerRadius);
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
    public void OnEndDrag(PointerEventData eventData){}
    public void OnBeginDrag(PointerEventData eventData) {}
}
