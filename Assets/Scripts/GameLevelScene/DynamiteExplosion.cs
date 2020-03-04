using UnityEngine;

public class DynamiteExplosion : MonoBehaviour
{
    [SerializeField]private float ExplosionRadius = 5.0f;
    [SerializeField]private float ExplosionPower = 300.0f;
    public void Explode() 
    {
        Vector3 ExplosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPosition, ExplosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            EnemyMovement enemyMovement = hit.GetComponent<EnemyMovement>();
            if (rb != null)
            {
                rb.AddExplosionForce(ExplosionPower, ExplosionPosition, ExplosionRadius);
                enemyMovement.StopMovement();
            }
        }
        SceneController.Dynamite--;

        Debug.Log("dynamite left: " + SceneController.Dynamite);
    }
}
