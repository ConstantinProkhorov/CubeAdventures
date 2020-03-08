public sealed class RotationEnemyMovement : EnemyMovement //used for UIDiamond
{
    public void Update()
    {
        Rotation();
    }
    protected override void Rotation()
    {
        transform.Rotate(0, 0, -RotationSpeed);
    }
}
