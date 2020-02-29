public sealed class VerticalEnemyMovement : EnemyMovement
{
    public void Update()
    {
        Movement();
        Rotation();
        Destroy();
    }
}
