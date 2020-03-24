using UnityEngine;
public class DynamiteMovement : MonoBehaviour
{
    [SerializeField] float DynamiteSpeed;
    [SerializeField] float RotationSpeed;

    void Update()
    {
        transform.Translate(0, DynamiteSpeed * Time.deltaTime, 0, Space.World);
        transform.Rotate(0, 0, RotationSpeed);
    }
}

