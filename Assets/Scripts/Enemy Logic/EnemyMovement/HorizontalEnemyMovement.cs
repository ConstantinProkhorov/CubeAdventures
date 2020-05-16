using UnityEngine;
using GameWork.Unity.Directions;

public class HorizontalEnemyMovement : EnemyMovement
{
    [SerializeField] private float SpeedMultiplier = 2.0f;
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
        FlyDirection = SpeedMultiplier * (FallingSpeed * (float)direction);
        // этого тут не должно быть
        GetComponent<SphereCollider>().enabled = true;
    }
    public void Update()
    {
        Movement();
        Rotation();
    }
    protected override void Movement()
    {
        Rigidbody.MovePosition(new Vector3(transform.position.x + FlyDirection * Time.deltaTime, transform.position.y, transform.position.z));
    }
}
