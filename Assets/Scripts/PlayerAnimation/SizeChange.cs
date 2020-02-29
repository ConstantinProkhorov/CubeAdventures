using UnityEngine;
using System.Collections;
public class SizeChange : MonoBehaviour
{
    // переменные для ввода в инспекторе
    [SerializeField] private int ResizeDuration = 1;
    [Tooltip("Size multiplier, increases size by given amount.")]
    [SerializeField]
    private float SizeMultiplier = 1.1f;
    private Vector3 PlayerSize;
    public void Start()
    {
        PlayerSize = gameObject.transform.localScale;
    }
    public void ChangeSize()
    {
        StartCoroutine(Resize());
    }
    private IEnumerator Resize()
    {
        gameObject.transform.localScale = PlayerSize * SizeMultiplier;
        yield return new WaitForSeconds(ResizeDuration);
        gameObject.transform.localScale = PlayerSize;
    }
}
