﻿using UnityEngine;
using System.Collections;

public class DynamiteExplosion : MonoBehaviour
{
    [SerializeField]private float ExplosionRadius = 5.0f;
    [SerializeField]private float ExplosionPower = 5000.0f;
    private void Start()
    {
        StartCoroutine("ExplosionDelay");
    }

    private IEnumerator ExplosionDelay()

    {
        yield return new WaitForSeconds(0.9f);
        Explode();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


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
