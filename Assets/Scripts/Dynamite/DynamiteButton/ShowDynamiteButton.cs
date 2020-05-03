using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Logic of how DynamiteButton is hidden
/// </summary>
public class ShowDynamiteButton : MonoBehaviour
{
    [SerializeField] private Button DynamiteButton = null;
    public bool IsHidden { get; private set; }
    public void Show()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        DynamiteButton.interactable = true;
        IsHidden = false;
    }
    public void Hide()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        DynamiteButton.interactable = false;
        IsHidden = true;
    }
}
