public sealed class VerticalEnemyMovement : EnemyMovement
{
    public void FixedUpdate()
    {
        Movement();
        Rotation();
    }
}
