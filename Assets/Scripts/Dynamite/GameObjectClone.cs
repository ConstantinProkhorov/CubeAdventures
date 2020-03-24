using UnityEngine;
public class GameObjectClone : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] private GameLevelSceneController thisSceneController;
    public void CloneToCanvas()
    {
        Transform PlayerTransform = thisSceneController.Player.transform;

        GameObject clone = Resources.Load<GameObject>("Forms/Dynamite") as GameObject;
        GameObject Explosion = Resources.Load<GameObject>("Forms/Explosion") as GameObject;

        clone = Instantiate(clone, PlayerTransform.position, Quaternion.identity) as GameObject;
        Explosion = Instantiate(Explosion, PlayerTransform.position, Quaternion.identity) as GameObject;

        clone.transform.SetParent(canvas.transform);
        Explosion.transform.SetParent(clone.transform);

        clone.transform.localScale = new Vector3(2,2,2);
        clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, 2);
        //clone.transform.Translate(0, 100 * Time.deltaTime, 0, Space.World);
    }
}