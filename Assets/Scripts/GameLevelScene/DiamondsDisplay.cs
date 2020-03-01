using UnityEngine;
using UnityEngine.UI;

public class DiamondsDisplay : MonoBehaviour
{
    public Text diamondsDisplay;

    void Update()
    {
        diamondsDisplay.text = SceneController.Diamonds.ToString();
    }
}
