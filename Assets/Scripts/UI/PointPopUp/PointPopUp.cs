using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointPopUp : MonoBehaviour
{
    [SerializeField] private GameObject PointsPopUp;
    private float PopUpOffset = 0.8f;
    private GameObject PopUp;
    private Vector3 PlayerPosition;
#pragma warning disable 649
    [SerializeField] Canvas canvas;
    /// <summary>
    /// Instantiates PopUp.
    /// </summary>
    /// <param name="position">Current position. Based on it position for PopUp will be calculated.</param>
    /// <param name="numberToShow">Nubmer that popUp will show.</param>
    public void CreatePopUp(Vector3 position, int numberToShow)
    {
        PlayerPosition = position;
        StartCoroutine(CreatePopUp(numberToShow));      
    }
    private IEnumerator CreatePopUp(int numberToShow)
    {
        if (PopUp != null)
        {
            Destroy(PopUp);
        }
        Vector3 PopUpPosition = new Vector3(PlayerPosition.x + PopUpOffset, PlayerPosition.y + PopUpOffset, PlayerPosition.z);
        PopUp = Instantiate(PointsPopUp, PopUpPosition, Quaternion.identity, canvas.transform);
        PopUp.GetComponent<PointPopUpTextUpdater>().ShowText(numberToShow);
        PopUp.transform.position = UIElementsPositionAdjuster.GetAdjustedPosition(PopUp.GetComponent<RectTransform>());
        yield return new WaitForSeconds(0.5f);
        Destroy(PopUp);
    }
}
