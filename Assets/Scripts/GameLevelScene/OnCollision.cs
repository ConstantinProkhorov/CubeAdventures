using UnityEngine;

public class OnCollision : MonoBehaviour
// TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
// а сейчас? 
// по идеи должно быть класс у игрока, который вызывает 1 класс у фигуры, который уже и реализует последствия столкновения. Класс на игроке позволяет избежать 
// многочисленных проверок при столкновении врагов между собой. 
// Но как в таком случае реализовать изменеия очков? 
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
        AudioSource audioSource = col.gameObject.GetComponent<AudioSource>();
        if (audioSource != null & !Settings.IsSoundsMuted)
        {
            audioSource.Play();
        }
        if (col.gameObject.CompareTag("Enemy")) 
        {
            SceneLoadManager.SceneLoad("EndScore");
        }
        else if (col.gameObject.CompareTag("pointsgiver"))
        {
            GameLevelSceneController.ScoreGainedOnLevel.Add();
            PopUp.OnCollision(gameObject.transform.position);
            sizeChange.ChangeSize();
        }
        else if (col.gameObject.CompareTag("collectible"))
        {
            SceneController.Diamonds++;
            sizeChange.ChangeSize();
        }
        col.gameObject.GetComponent<RemoveGameObject>().Remove();
    }
}

