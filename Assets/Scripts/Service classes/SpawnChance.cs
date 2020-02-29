using UnityEngine;

public static class SpawnChance
{
    public static bool Get(int percent)
    {
        if (percent == 0)
        {
            return false;
        }
        else if (Random.Range(1, 101) <= percent)
        {
            return true;
        }
        return false;
    }
}
