using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectClone : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] private GameLevelSceneController thisSceneController;
    Transform CanvasTransform;
    public void CloneToCanvas()
    {
        Transform PlayerTransform = thisSceneController.Player.transform;

        GameObject clone = Resources.Load<GameObject>("Forms/Dynamite") as GameObject;
        GameObject Explosion = Resources.Load<GameObject>("Forms/Explosion") as GameObject;
        clone = Instantiate(clone, PlayerTransform.position, Quaternion.identity) as GameObject;
        Explosion = Instantiate(Explosion, PlayerTransform.position, Quaternion.identity) as GameObject;
        //clone.GetComponent<ShowDynamiteIcon>().enabled = false;
        //clone.GetComponent<Button>().enabled = false;
        CanvasTransform = canvas.transform;
        clone.transform.SetParent(CanvasTransform);
        Explosion.transform.SetParent(clone.transform);
        clone.transform.localScale = new Vector3(3,3,3);
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, 2);
    }
}