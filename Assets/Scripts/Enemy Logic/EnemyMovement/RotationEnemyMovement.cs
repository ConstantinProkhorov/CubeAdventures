public sealed class RotationEnemyMovement : EnemyMovement
{
    public void Update()
    {
        Rotation();
    }
    public override void Rotation()
    {
        transform.Rotate(0, 0, -rotationSpeed);
    }
}
