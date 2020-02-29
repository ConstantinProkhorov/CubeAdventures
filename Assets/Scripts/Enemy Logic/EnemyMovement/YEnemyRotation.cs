public sealed class YEnemyRotation : EnemyMovement
{
    // used for UICoin
    public void Update()
    {
        Rotation();
    }
    protected override void Rotation()
    {
        transform.Rotate(0, -rotationSpeed, 0);
    }
}
