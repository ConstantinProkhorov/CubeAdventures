using UnityEngine;
using GameWork.Unity.Directions;

public class FormsSlide : MonoBehaviour
{
    private const float slideSpeed = 0.3f;
    private readonly float spawnPosition = ScreenBorders.Left + ScreenBorders.HalfCamWidth / 3;
    private readonly float DestroyPosition = ScreenBorders.HalfCamWidth * 2;
    public static HorizontalDirection direction = HorizontalDirection.left;

    void Update()
    {
        Move(direction);
    }

    private void Move(HorizontalDirection _direction)
    {
        if (_direction == HorizontalDirection.left)
        {
            if (transform.position.x > spawnPosition)
            {
                transform.Translate((Vector3.left) * slideSpeed, Space.World);
            }         
        }
        else if (_direction == HorizontalDirection.right)
        {
            if (transform.position.x < DestroyPosition)
            {
                transform.Translate((Vector3.right) * slideSpeed, Space.World);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(Vector3.up, Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(Vector3.down, Space.World);
        }
    }
}
