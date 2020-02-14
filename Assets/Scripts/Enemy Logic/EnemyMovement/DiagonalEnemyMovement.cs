using UnityEngine;
using GameWork.Unity.Directions;

public sealed class DiagonalEnemyMovement : EnemyMovement
{
#pragma warning disable 649
    public HorizontalDirection direction;
    public float FallDirection;
    [Tooltip("Множитель скорости падения для определения угла падения")] // TODO: заменить на пересчет через синус, чтобы можно было вводить значение угла
    [SerializeField] private float FallInclination = 0.4f;
    public new void Start()
    {
        Debug.Log("horizontal direction is" + direction);
        base.Start();
        FallDirection = FallInclination * fallingSpeed * (float)direction.GetRandom();
        Debug.Log("falling Speed in Awake = " + fallingSpeed);
        Debug.Log("fallDirection in Awake = " + FallDirection);
    }
    public void Update()
    {
        Movement();
        Destroy();
    }
    public override void Movement()
    {
        Debug.Log("actual inclination = " + FallDirection * Time.deltaTime);
        this.transform.Translate(FallDirection * Time.deltaTime, fallingSpeed * Time.deltaTime, 0, Space.World);
    }
}
