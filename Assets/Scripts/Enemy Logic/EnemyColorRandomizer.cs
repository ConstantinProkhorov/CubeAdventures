using UnityEngine;

public interface IColorRandomizer
{
    void AssignColor(GameObject figure);
}

public class EnemyColorRandomizer : IColorRandomizer
{
    void IColorRandomizer.AssignColor(GameObject figure)
    {
        figure.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
