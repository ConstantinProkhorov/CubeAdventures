using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerAnimation : MonoBehaviour
{
    [SerializeField] private int TextSizeIncrement = 3;
    [SerializeField] private float Duration = 0.5f;
    public void RunAnimation(Text text) => StartCoroutine(TextSizeChange(text));
    private IEnumerator TextSizeChange(Text text)
    {
        text.fontSize += TextSizeIncrement;
        yield return new WaitForSeconds(Duration);
        text.fontSize -= TextSizeIncrement;
    }
}
