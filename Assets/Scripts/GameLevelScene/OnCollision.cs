using UnityEngine;

public class OnCollision : MonoBehaviour 
// TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
// а сейчас? 
{
    private GameLevelSceneController GameLevelSceneController;
    private PointPopUp PopUp;
    private SizeChange sizeChange;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        GameLevelSceneController = ScriptHolder.GetComponent<GameLevelSceneController>();
        PopUp = ScriptHolder.GetComponent<PointPopUp>();
        sizeChange = gameObject.GetComponent<SizeChange>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy")) 
        {
            SceneLoadManager.SceneLoad("EndScore");
        }
        else if (col.gameObject.CompareTag("pointsgiver"))
        {
            Destroy(col.gameObject);
            GameLevelSceneController.ScoreGainedOnLevel.Add();
            PopUp.OnCollision(gameObject.transform.position);
            sizeChange.ChangeSize();
        }
        else if (col.gameObject.CompareTag("collectible"))
        {
            SceneController.Diamonds++;
            Destroy(col.gameObject);
            sizeChange.ChangeSize();
        }      
    }
}

