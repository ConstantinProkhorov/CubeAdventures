using UnityEngine;
using GameWork.Unity.Directions;

public class HorizontalEnemyMovement : EnemyMovement
{
    public HorizontalDirection direction;
    private float FlyDirection;
    public void Awake()
    {
        if (gameObject.transform.position.x < 0)
        {
            direction = HorizontalDirection.left;
        }
        else
        {
            direction = HorizontalDirection.right;
        }
    }
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

    protected override void Movement()
    {
        transform.Translate(FlyDirection * Time.deltaTime, 0, 0, Space.World);
    }
}
