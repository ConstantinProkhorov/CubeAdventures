using GameWork.Unity.Directions;
using UnityEngine;

public class HorizontalEnemyMovement : EnemyMovement
{
    public float direction = (float)HorizontalDirection.noDirection;
    public void Update()
    {
        Movement();
        Rotation();
        Destroy();
    }

    public override void Movement()
    {
        transform.Translate(fallingSpeed * Time.deltaTime * (float)direction, 0, 0, Space.World);
    }
}
