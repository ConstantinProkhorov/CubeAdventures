using System.Collections;
using UnityEngine;

public class PointPopUp : MonoBehaviour
{
    public GameObject PointsPopUp;
    private GameObject PopUp;
    private Vector3 PlayerPosition;
#pragma warning disable 649
    [SerializeField] Canvas canvas;

    public void OnCollision(Vector3 position)
    {
        PlayerPosition = position;
        StartCoroutine(CreatePopUp());      
    }

    private IEnumerator CreatePopUp()
    {
        if (PopUp != null)
        {
            Destroy(PopUp);
        }
        PopUp = Instantiate(PointsPopUp, new Vector3(PlayerPosition.x + 0.6f, PlayerPosition.y + 0.6f, PlayerPosition.z), Quaternion.identity, canvas.transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(PopUp);
    }
}
