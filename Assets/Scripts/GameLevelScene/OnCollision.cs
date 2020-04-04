using System;
using UnityEngine;

public class OnCollision : MonoBehaviour
// TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
// а сейчас? 
{
    public event Action EnemyCollision;
    public event Action CoinCollision;
    public event Action DiamondCollision;

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
        ////col.gameObject.GetComponent<AudioSource>().Play();
        //AudioSource audioSource = col.gameObject.GetComponent<AudioSource>() as AudioSource;
        ////audioSource.Play();
        //if (audioSource is AudioSource/*audioSource != null & *//*!audioSource.isPlaying*/)
        //{
        //    Debug.Log("in");
        //    audioSource.Play();
        //}
        if (col.gameObject.CompareTag("Enemy")) 
        {
            SceneLoadManager.SceneLoad("EndScore");
        }
        else if (col.gameObject.CompareTag("pointsgiver"))
        {
            CoinCollision();
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

