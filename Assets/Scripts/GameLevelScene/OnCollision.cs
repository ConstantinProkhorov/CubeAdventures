using UnityEngine;

public class OnCollision : MonoBehaviour
// TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
// а сейчас? 
// по идеи должно быть класс у игрока, который вызывает 1 класс у фигуры, который уже и реализует последствия столкновения. Класс на игроке позволяет избежать 
// многочисленных проверок при столкновении врагов между собой. 
// Но как в таком случае реализовать изменеия очков? 
{
    private PointPopUp PopUp;
    private SizeChange sizeChange;
    private int ScorePerCoin;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        PopUp = ScriptHolder.GetComponent<PointPopUp>();
        sizeChange = gameObject.GetComponent<SizeChange>();
        ScorePerCoin = ActiveLevelData.ScorePerCoin;
    }
    void OnCollisionEnter(Collision col)
    {
        AudioSource audioSource = col.gameObject.GetComponent<AudioSource>();
        if (audioSource != null & Settings.IsSoundsOn)
        {
            audioSource.Play();
        }
        if (col.gameObject.CompareTag("Enemy")) 
        {
            SceneLoadManager.SceneLoad("EndScore");
        }
        else if (col.gameObject.CompareTag("pointsgiver"))
        {
            SceneController.ScoreGainedOnLevel.AddToAmount(ScorePerCoin);
            SceneController.Score += ScorePerCoin;
            PopUp.CreatePopUp(gameObject.transform.position, ScorePerCoin);
            sizeChange.ChangeSize();
        }
        else if (col.gameObject.CompareTag("collectible"))
        {
            int diamondsGainedAmount = 1;
            SceneController.DiamondsGainedOnLevel.AddToAmount(diamondsGainedAmount);
            SceneController.Diamonds += diamondsGainedAmount;
            PopUp.CreatePopUp(gameObject.transform.position, diamondsGainedAmount);
            sizeChange.ChangeSize();
        }
        RemoveGameObject removeGameObject = col.gameObject.GetComponent<RemoveGameObject>();
        if (removeGameObject != null)
        {
            col.gameObject.GetComponent<RemoveGameObject>().Remove();
        }
    }
}

