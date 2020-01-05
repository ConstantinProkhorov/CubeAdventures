using UnityEngine;

public sealed class DiagonalEnemyMovement : EnemyMovement
{
#pragma warning disable 649
    private HorizontalDirection direction;
    private float PrecalculatedDirection;
    [Tooltip("Множитель скорости падения для определения угла падения")] // TODO: заменить на пересчет через синус, чтобы можно было вводить значение угла
    [SerializeField] private float FallInclination = 0.04f;
    public new void Start()
    {
        level level_ = GameObject.Find("ScriptHolder").GetComponent<level>();
        FallInclination = level_.levelFallInclination;
        base.Start();
        PrecalculatedDirection = FallInclination * fallingSpeed * (float)direction.GetRandom();
    }
    public void Update()
    {
        Movement();
        Destroy();
    }
    public override void Movement()
    {
        transform.Translate(PrecalculatedDirection * Time.deltaTime, fallingSpeed * Time.deltaTime, 0, Space.World);
    }
}
