using UnityEngine;
using GameWork.Unity.Directions;

public class HorizontalEnemyMovement : EnemyMovement
{
    public HorizontalDirection direction;
    private float FlyDirection;
    public new void Start()
    {
        base.Start();
        FlyDirection = fallingSpeed * (float)direction;
    }
    public void Update()
    {
        Movement();
        Rotation();
        Destroy();
    }

    public override void Movement()
    {
        transform.Translate(FlyDirection * Time.deltaTime, 0, 0, Space.World);
    }
}
