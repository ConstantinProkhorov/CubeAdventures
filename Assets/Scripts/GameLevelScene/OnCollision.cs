using UnityEngine;

public class OnCollision : MonoBehaviour
// TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
// а сейчас? 
// по идеи должно быть класс у игрока, который вызывает 1 класс у фигуры, который уже и реализует последствия столкновения. Класс на игроке позволяет избежать 
// многочисленных проверок при столкновении врагов между собой. 
// Но как в таком случае реализовать изменеия очков? 
{
    private IPopUpFactory PopUpFactory;
    private SizeChange sizeChange;
    private int ScorePerCoin;
    void Start()
    {
        //интересно, используя scriptableObject, могу ли я избежать операций Find?
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        PopUpFactory = ScriptHolder.GetComponent<IPopUpFactory>();
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
            IPopUp PopUp = PopUpFactory.CreatePopUp(gameObject.transform.position);
            PopUp.SetOutput(ScorePerCoin);
            sizeChange.ChangeSize();
        }
        else if (col.gameObject.CompareTag("collectible"))
        {
            int diamondsGainedAmount = 1;
            SceneController.DiamondsGainedOnLevel.AddToAmount(diamondsGainedAmount);
            SceneController.Diamonds += diamondsGainedAmount;
            IPopUp PopUp = PopUpFactory.CreatePopUp(gameObject.transform.position);
            PopUp.SetOutput(diamondsGainedAmount);
            sizeChange.ChangeSize();
        }
        RemoveGameObject removeGameObject = col.gameObject.GetComponent<RemoveGameObject>();
        if (removeGameObject != null)
        {
            col.gameObject.GetComponent<RemoveGameObject>().Remove();
        }
    }
}

