using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerAnimation : MonoBehaviour
{
    public int TextSizeIncrement = 3;

    public void RunAnimation(Text text)
    {
        StartCoroutine(TextSizeChange(text));
    }

    private IEnumerator TextSizeChange(Text text)
    {
        yield return new WaitForSeconds(0.2f);
        text.fontSize += TextSizeIncrement;
        yield return new WaitForSeconds(0.5f);
        text.fontSize -= TextSizeIncrement;
    }
}
