using UnityEngine;
using GameWork.Unity.Directions;

public sealed class DiagonalEnemyMovement : EnemyMovement
{
#pragma warning disable 649
    private HorizontalDirection direction;
    public float FallDirection;
    [Tooltip("Множитель скорости падения для определения угла падения")] // TODO: заменить на пересчет через синус, чтобы можно было вводить значение угла
    [SerializeField] private float FallInclination = 0.04f;
    public new void Start()
    {
        base.Start();
        FallDirection = FallInclination * fallingSpeed * (float)direction.GetRandom();
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
}
