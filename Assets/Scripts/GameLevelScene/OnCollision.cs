using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour // TODO: Класс слишком большой и многофункциональный, лучше бы виделить отсюда все(?) результаты столкновений в отдельные скрипты
{
    private PointPopUp PopUp;
    private SizeChange sizeChange;
    private ContinuePlayingWindow ContinuePlayingWindow;
    private SpecialEffects CurrentPlayerEffect;
    [SerializeField] private LevelSceneController thisSceneController;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        PopUp = ScriptHolder.GetComponent<PointPopUp>();
        ContinuePlayingWindow = ScriptHolder.GetComponent<ContinuePlayingWindow>();
        thisSceneController = ScriptHolder.GetComponent<LevelSceneController>();
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

        else if (col.gameObject.CompareTag("transparent"))
        {
            SetEffect(col.gameObject);
            thisSceneController.DecrementEnemyCounter(col.gameObject);
        }

        else if (col.gameObject.CompareTag("collectible"))
        {
            SceneController.diamonds++;
            Destroy(col.gameObject);
            sizeChange.ChangeSize();
            thisSceneController.DecrementEnemyCounter(col.gameObject);
        }      
    }

    private void SetEffect(GameObject figure)
    {
        TransparentFigureEffect data = figure.GetComponent<TransparentFigureEffect>();
        switch (data.FigureEffect)
        {            
            case SpecialEffects.Invincibility:
                StartCoroutine(SetInvincibility(data.EffectDuration));
                Destroy(figure);
                break;
            case SpecialEffects.Explosion:
                Explosion(figure);
                Destroy(figure);
                break;
            default:
                break;
        }
    }

    private IEnumerator SetInvincibility(byte duration)
    {
        CurrentPlayerEffect = SpecialEffects.Invincibility;
        yield return new WaitForSeconds(duration);
        CurrentPlayerEffect = SpecialEffects.NoEffect;
    }

    private void Explosion(GameObject _figure) // метод вызывающий взрыв, расталкивающий фигуры.
    {
        float radius = 5.0F;
        float power = 300.0F;
        Vector3 explosionPos = _figure.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius);
            }
        }
    }
}

