﻿using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int rotationSpeed = 1;
    private (float min, float max) destroyPosY;
    private (float min, float max) destroyPosX;
    protected float fallingSpeed;
    private LevelSceneController thisSceneController;
    protected void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        thisSceneController = ScriptHolder.GetComponent<LevelSceneController>();
        fallingSpeed = ActiveLevelData.FallingSpeed;
        destroyPosY = (ScreenBorders.Buttom + ScreenBorders.Buttom / 2, ScreenBorders.Top + ScreenBorders.Top / 2);       
        destroyPosX = (ScreenBorders.Left + ScreenBorders.Left / 2, ScreenBorders.Right + ScreenBorders.Right / 2);
    }
    public virtual void Movement()
    {     
        transform.Translate(0, fallingSpeed * Time.deltaTime, 0, Space.World);
    }
    public virtual void Rotation()
    {
        transform.Rotate(0, -rotationSpeed, -rotationSpeed);
    }

    public virtual void Destroy() // TODO: ок, а есть ли еще более оптимальный способ?
    {
        if (transform.localPosition.y < destroyPosY.min || transform.localPosition.y > destroyPosY.max)
        {
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
        }
        if (transform.localPosition.x > destroyPosX.max || transform.localPosition.x < destroyPosX.min)
        {
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
        }
    }
}
