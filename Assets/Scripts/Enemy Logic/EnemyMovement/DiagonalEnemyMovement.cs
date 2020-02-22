using UnityEngine;
using GameWork.Unity.Directions;

public sealed class DiagonalEnemyMovement : EnemyMovement
{
#pragma warning disable 649
    public HorizontalDirection direction;
    public float FallDirection;
    [Tooltip("Множитель скорости падения для определения угла падения")] // TODO: заменить на пересчет через синус, чтобы можно было вводить значение угла
    [SerializeField] private float FallInclination = 0.2f;
    public void Awake()
    {
        direction = GetRandomDirection();
    }
    public new void Start()
    {
        base.Start();
        FallDirection = FallInclination * fallingSpeed * (float)direction;
    }
    public void Update()
    {
        Movement();
        Destroy();
    }
    public override void Movement()
    {
        transform.Translate(FallDirection * Time.deltaTime, fallingSpeed * Time.deltaTime, 0, Space.World);
    }

    private HorizontalDirection GetRandomDirection()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            return HorizontalDirection.right;
        }
        else
        {
            return HorizontalDirection.left;
        }
    }
}
