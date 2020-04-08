using System.Collections;
using UnityEngine;
/// <summary>
/// Size change animation, runs after instantiation
/// </summary>
public class DynamiteAnimation : MonoBehaviour
{
    [Tooltip("SizeIncraseIncrement is size increse step in %.")]
    [SerializeField] private float SizeIncraseIncrement = 3.0f;
    [Tooltip("Initial size is multiplied by this value. Max size of the figure during animation.")]
    [SerializeField] private float MaxSize = 1.5f;
    [Tooltip("Initial size is multiplied by this value. Size of the figure when animation ends.")]
    [SerializeField] private float ResultingSize = 1.5f;
    IEnumerator Start()
    {
        Vector3 dynamiteScale = gameObject.transform.lossyScale;
        float increment = dynamiteScale.x / 100 * SizeIncraseIncrement;
        for (float i = dynamiteScale.x; i < dynamiteScale.x * MaxSize; i += increment)
        {
            transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(.02f);
        }
        yield return new WaitForSeconds(0.1f);
        for (float i = MaxSize; i > dynamiteScale.x * ResultingSize; i -= increment)
        {
            transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(.02f);
        }
    }
}
