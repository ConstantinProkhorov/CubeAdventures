using UnityEngine;

public class TapControlls : MonoBehaviour
{
    public GameLevelSceneController thisSceneController;
    private GameObject player;
    public static bool GameIsPaused = false;
    private float playerRadius;
    float minX, maxX, minY, maxY;
    public void Start()
    {
        minX = ScreenBorders.Left;
        maxX = ScreenBorders.Right;
        minY = ScreenBorders.Buttom;
        maxY = ScreenBorders.Top;
        player = thisSceneController.Player;
        playerRadius = player.transform.localScale.x / 2;
    }
    void OnMouseDown()
    {
        if (!GameIsPaused)
        {
            Vector3 playerPosition = player.transform.position; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

            playerPosition.x = hit.point.x;
            playerPosition.y = hit.point.y;
            playerPosition.x = Mathf.Clamp(playerPosition.x, minX + playerRadius, maxX - playerRadius);
            playerPosition.y = Mathf.Clamp(playerPosition.y, minY + playerRadius, maxY - playerRadius);

            player.transform.position = playerPosition;
        }
    }
}
