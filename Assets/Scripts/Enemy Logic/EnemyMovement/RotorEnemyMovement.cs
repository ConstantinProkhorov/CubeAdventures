﻿using GameWork.Unity.Directions;

public sealed class RotorEnemyMovement : EnemyMovement
{
    public VerticalDirection RotationDirection;
    public new void Start()
    {
        base.Start();
        RotationDirection = RotationDirection.GetRandom();
    }
    public void Update()
    {
        Movement();
        Rotation();
        Destroy();
    }
    protected override void Rotation()
    {
        transform.Rotate(0, 0, rotationSpeed * (float)RotationDirection);
    }
}