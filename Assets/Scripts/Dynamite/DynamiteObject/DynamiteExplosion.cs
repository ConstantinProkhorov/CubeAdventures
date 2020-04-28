using UnityEngine;
/// <summary>
/// Exolosion interaction with colliders of affected figures.
/// </summary>
public class DynamiteExplosion : MonoBehaviour
{
    [SerializeField] private float ExplosionRadius = 5.0f;
    [SerializeField] private float ExplosionUpwardModifier = 2.0f;
    [SerializeField] private float ExplosionPower = 5000.0f;
    /// <summary>
    /// Start Explosion.
    /// </summary>
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
                rb.AddExplosionForce(ExplosionPower, ExplosionPosition, ExplosionRadius, ExplosionUpwardModifier);
                enemyMovement.StopMovement();
            }
        }
    }
}
