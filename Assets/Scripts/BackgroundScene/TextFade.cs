using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Text txt;
#pragma warning disable 649
    [SerializeField] private Outline oLine;

    void Update()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time/2.0f, 1.0f));
        oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, txt.color.a - 0.3f);
    }
}
