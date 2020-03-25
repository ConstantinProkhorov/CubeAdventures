using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Text Text;
#pragma warning disable 649
    [SerializeField] private Outline Outline;

    void Update()
    {
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Mathf.PingPong(Time.time/2.0f, 1.0f));
        Outline.effectColor = new Color(Outline.effectColor.r, Outline.effectColor.g, Outline.effectColor.b, Text.color.a - 0.3f);
    }
}
