﻿using UnityEngine;
public class EnemySpawnRandomizer
{
    private float[] TopSpawnPositions;
    private readonly float SpawnPositionY;
    //private (float left, float right) SpawnPositionX;
    private readonly (float bottom, float top) VerticalSpawnBorders = (-3.5f, 3.0f);
    private readonly float SpawnStep = 0.6f;
    public EnemySpawnRandomizer()
    {
        CalculateTopSpawnPositions();
        SpawnPositionY = ScreenBorders.Top + ScreenBorders.Top / 3f;
        //SpawnPositionX.right = ScreenBorders.Right;
        //SpawnPositionX.left = -SpawnPositionX.right;
    }
    private float[] CalculateTopSpawnPositions() // расчет возможных позиций для создания фигур
    { 
        int length = (int)((ScreenBorders.HalfCamWidth * 2) / SpawnStep);
        TopSpawnPositions = new float[length];
        for (int i = 1; i < TopSpawnPositions.Length; i++)
        {
            TopSpawnPositions[i] = ScreenBorders.Left + SpawnStep * i;
        }
        return TopSpawnPositions;
    }
    public Vector3 GetRandomSpawnPosition(string enemyName)
    {
        if (enemyName == "HorizontalEnemy") //TODO: подумать. Сравнение строк не оптимально. На что я могу это заменть?
        {
            return new Vector3(GetRandomSpawnSide(), Random.Range(VerticalSpawnBorders.bottom, VerticalSpawnBorders.top), 0);
        }
        else
        {
            int pos = Random.Range(0, TopSpawnPositions.Length);
            float position = TopSpawnPositions[pos];
            return new Vector3(position, SpawnPositionY, 0);
        }
    }
    private float GetRandomSpawnSide()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            return ScreenBorders.Right;
        }
        else
        {
            return ScreenBorders.Left;
        }
    }
}
