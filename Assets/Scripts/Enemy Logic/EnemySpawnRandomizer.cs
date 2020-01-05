using UnityEngine;

public class EnemySpawnRandomizer : MonoBehaviour
{
    private float[] spawnPosition;

    protected float[] SpawnPositionCalculator() // расчет возможных позиций для создания фигур
    {
        float figuresize = Enemy_Creator.figuresize * 2;
        int length = (int)((ScreenBorders.HalfCamWidth * 2) / figuresize);
        spawnPosition = new float[length];
        for (int i = 1; i < spawnPosition.Length; i++)
        {
            spawnPosition[i] = ScreenBorders.Left + figuresize * i;
        }
        return spawnPosition;
    }
    protected float Position_Randomizer(float[] positionArray)
    {
        int pos = Random.Range(0, positionArray.Length);
        float position = spawnPosition[pos];
        return position;
    }

}
