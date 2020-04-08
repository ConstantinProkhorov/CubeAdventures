using System.Collections;
using UnityEngine;
/// <summary>
/// Physics part of dynamite explosion
/// </summary>
public class DynamiteExplosion : MonoBehaviour
{
    [SerializeField] private float ExplosionRadius = 5.0f;
    [SerializeField] private float ExplosionPower = 5000.0f;
    //public IEnumerator Start()
    //{
    //    //Explode();
    //    //GetComponent<Image>().enabled = false;
    //    //GetComponent<DynamiteMovement>().enabled = false;
    //    //yield return new WaitForSeconds(0.5f);
    //    //Destroy(gameObject);
    //}
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
    }
}
