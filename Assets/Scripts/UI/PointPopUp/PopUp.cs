using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Logic of how PopUp displays text.
/// </summary>
public class PopUp : MonoBehaviour, IPopUp
{
    [SerializeField] private Text PointPopUpText;
    void IPopUp.SetOutput(int numberToShow)
    {
        PointPopUpText.text = $"+{numberToShow}";
    }
}
