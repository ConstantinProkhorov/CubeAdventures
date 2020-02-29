using UnityEngine;

public class StarsSet : MonoBehaviour
{
	void Start()
	{
        Object[] m;
        m = FindObjectsOfType<Star>();
        foreach (Object n in m)
        {
            Star star = (Star)n;
            star.GoldStar();
        }
    }
}
