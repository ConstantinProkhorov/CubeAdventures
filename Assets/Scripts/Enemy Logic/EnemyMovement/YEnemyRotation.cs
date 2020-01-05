public sealed class YEnemyRotation : EnemyMovement
{
    public void Update()
    {
        Rotation();
    }
    public override void Rotation()
    {
        transform.Rotate(0, -rotationSpeed, 0);
    }
}
