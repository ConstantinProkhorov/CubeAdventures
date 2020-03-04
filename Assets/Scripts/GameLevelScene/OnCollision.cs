using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour // TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
{
    private PointPopUp PopUp;
    private SizeChange sizeChange;
    private ContinuePlayingWindow ContinuePlayingWindow;
    private SpecialEffects CurrentPlayerEffect;
    [SerializeField] private GameLevelSceneController thisSceneController;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        PopUp = ScriptHolder.GetComponent<PointPopUp>();
        ContinuePlayingWindow = ScriptHolder.GetComponent<ContinuePlayingWindow>();
        thisSceneController = ScriptHolder.GetComponent<GameLevelSceneController>();
        sizeChange = gameObject.GetComponent<SizeChange>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") && (CurrentPlayerEffect != SpecialEffects.Invincibility)) 
        {
            ContinuePlayingWindow.OpenWindow(col.gameObject);
            thisSceneController.DecrementEnemyCounter(col.gameObject);
        }

        else if (col.gameObject.CompareTag("pointsgiver"))
        {
            thisSceneController.ScoreGainedOnLevel.Add(/*pointsAdded =*/ 10);
            Destroy(col.gameObject);
            thisSceneController.DecrementEnemyCounter(col.gameObject);
            PopUp.OnCollision(gameObject.transform.position);
            sizeChange.ChangeSize();
        }

        else if (col.gameObject.CompareTag("collectible"))
        {
            SceneController.Diamonds++;
            Destroy(col.gameObject);
            sizeChange.ChangeSize();
            thisSceneController.DecrementEnemyCounter(col.gameObject);
        }      
    }
    // TODO: оставленно тут временно, убрать.
    private IEnumerator SetInvincibility(byte duration)
    {
        CurrentPlayerEffect = SpecialEffects.Invincibility;
        yield return new WaitForSeconds(duration);
        CurrentPlayerEffect = SpecialEffects.NoEffect;
    }
}

