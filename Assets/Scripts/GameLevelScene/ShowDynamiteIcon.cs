using UnityEngine;
using System.Collections;

public class ShowDynamiteIcon : MonoBehaviour
{
    [SerializeField] private TimeDilation TimeDilation;
    [SerializeField] private GameLevelSceneController thisSceneController;
  void Start()
    {
        
        TimeDilation.TimeScaleSlowed += () =>
        {
            if (SceneController.Dynamite > 0)
            { 
                Vector3 position = thisSceneController.Player.transform.position - thisSceneController.Player.transform.lossyScale / 2;
                gameObject.transform.position = position;
            }
        };
        TimeDilation.TimeScaleNormalized += () => StartCoroutine(DelayedGameObjestDeactivation());
        DelayedGameObjestDeactivation();
    }
    private IEnumerator DelayedGameObjestDeactivation() 
    {
        yield return new WaitForEndOfFrame();
        gameObject.transform.position = new Vector3(200,200,200);
    }
}
