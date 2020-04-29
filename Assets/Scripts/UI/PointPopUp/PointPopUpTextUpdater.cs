using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Logic of how PopUp displays text.
/// </summary>
public class PointPopUpTextUpdater : MonoBehaviour
{
    [SerializeField] private Text PointPopUpText;
    /// <summary>
    /// PopUp shows numberToShow given in parameter.
    /// If method isn't called, PopUp will show nothing.
    /// </summary>
    public void ShowText(int numberToShow)
    {
        PointPopUpText.text = $"+{numberToShow}";
    }
}
