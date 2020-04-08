using UnityEngine;
public class DynamiteMovement : MonoBehaviour
{
    [SerializeField] float FlySpeed;
    [SerializeField] float RotationSpeed;
    void Update()
    {
        transform.Translate(0, FlySpeed * Time.deltaTime, 0, Space.World);
    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, RotationSpeed);
    }
}

