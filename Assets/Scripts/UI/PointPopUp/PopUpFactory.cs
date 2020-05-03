using System.Collections;
using UnityEngine;

public class PopUpFactory : MonoBehaviour, IPopUpFactory
{
    [SerializeField] private GameObject PointsPopUp;
    [SerializeField] private float DestructionDelay = 0.5f;
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
    IPopUp IPopUpFactory.CreatePopUp(Vector3 position)
    {
        if (PopUp != null)
        {
            Destroy(PopUp);
        }
        PlayerPosition = position;
        Vector3 PopUpPosition = new Vector3(PlayerPosition.x + PopUpOffset, PlayerPosition.y + PopUpOffset, PlayerPosition.z);
        PopUp = Instantiate(PointsPopUp, PopUpPosition, Quaternion.identity, canvas.transform);
        PopUp.transform.position = UIElementsPositionAdjuster.GetAdjustedPosition(PopUp.GetComponent<RectTransform>());
        StartCoroutine(DestroyPopUp());
        return PopUp.GetComponent<IPopUp>();
    }
    private IEnumerator DestroyPopUp()
    {
        yield return new WaitForSeconds(DestructionDelay);
        Destroy(PopUp);
    }
}


