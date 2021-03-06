﻿using UnityEngine;
using GameWork.Unity.Directions;

public sealed class DiagonalEnemyMovement : EnemyMovement
{
#pragma warning disable 649
    public HorizontalDirection direction;
    public float FallDirection;
    [Tooltip("Множитель скорости падения для определения угла падения")] // TODO: заменить на пересчет через синус, чтобы можно было вводить значение угла
    [SerializeField] private float FallInclination = 0.2f;
    public void Awake()
    {
        direction = direction.GetRandom();
    }
    public new void Start()
    {
        base.Start();
        FallDirection = FallInclination * FallingSpeed * (float)direction;
    }
    public void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    protected override void Movement()
    {
        Rigidbody.MovePosition(transform.position + new Vector3(FallDirection * Time.deltaTime, FallingSpeed * Time.deltaTime, 0));
    }
    public override void StopMovement()
    {
        FallDirection = 0.0f;
        base.StopMovement();
    }
}
