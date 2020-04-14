using UnityEngine;
using System.Collections;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int RotationSpeed = 1;
    [SerializeField] protected Rigidbody Rigidbody;
    protected float FallingSpeed;
    [SerializeField] public GameLevelSceneController thisSceneController;
    protected void Start()
    {
        FallingSpeed = ActiveLevelData.FallingSpeed;
    }
    protected virtual void Movement()
    {
        Rigidbody.MovePosition(transform.position + new Vector3(0, FallingSpeed * Time.deltaTime, 0));
        //transform.Translate(0, FallingSpeed * Time.deltaTime, 0, Space.World);
    }
    protected virtual void Rotation()
    {
        transform.Rotate(0, -RotationSpeed, -RotationSpeed);
    }
    public void OnBecameInvisible() => Destroy(gameObject);
    public void StopMovement()
    {
        StartCoroutine(GravityForcedFall());
    }
    private IEnumerator GravityForcedFall()
    {
        FallingSpeed = 0.0f;
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
