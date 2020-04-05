using System.Collections;
using UnityEngine;

public class RemoveFigure : RemoveGameObject
{
    [SerializeField] private Collider Collider;
    [SerializeField] private EnemyMovement EnemyMovement;
    [Tooltip("Delay in seconds before Destroy(gameObject) will be called")]
    [SerializeField] private float Delay = 2.0f;
    public override void Remove() => StartCoroutine(ExecuteRemoval());
    private IEnumerator ExecuteRemoval()
    {
        Collider.enabled = false;
        EnemyMovement.enabled = false;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }
}
